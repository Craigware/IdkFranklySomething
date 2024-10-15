using Godot;

namespace Entities
{
    [GlobalClass]
    public abstract partial class Entity : CharacterBody3D
    {
        [Signal] public delegate void EntityDeathEventHandler(Entity e);
        [Signal] public delegate void TurnFinishedEventHandler(Entity e); 
        [Export] public bool Ally;
        [Export] public Stats Stats;
        [Export] private Stats baseStats;
        [Export] public Vector3 targetPosition;
        [Export] public bool CanMove;

        public Entity() : this(new(), true) {}
        public Entity(Stats stats, bool isAlly) {
            baseStats = stats;
            Ally = isAlly;
        }

        public abstract void OnCol();
        public virtual void Die()
        {
            EmitSignal(SignalName.EntityDeath, this);
            QueueFree();
        }
 
        public virtual void Move()
        {
            if (!CanMove) return;
            Position = targetPosition;
            CanMove = false;
            EmitSignal(SignalName.TurnFinished, this);
        }

        public override void _Ready()
        {
            Stats = (Stats) baseStats.Duplicate(true);
            base._Ready();
        }
    }
}