using Godot;

namespace Entities
{
    [GlobalClass]
    public abstract partial class Entity : CharacterBody3D
    {
        [Signal] public delegate void EntityDeathEventHandler(Entity e);
        [Signal] public delegate void TurnFinishedEventHandler(Entity e); 
        [Export] public bool Ally;
        [Export] private Stats baseStats;
        [Export] public Vector3 targetPosition;
        [Export] public bool CanMove;
        [Export] public Inventory Inventory;

        [ExportCategory("CURRENT")]
        [Export] public Stats Stats;
        [Export] public Godot.Collections.Array<Attack> AvailableAttacks;

        public Entity() : this(new(), true) {}
        public Entity(Stats stats, bool isAlly) {
            baseStats = stats;
            Ally = isAlly;
            Inventory = new();
        }

        public virtual void Die()
        {
            EmitSignal(SignalName.EntityDeath, this);
            QueueFree();
        }

        public virtual void Move()
        {
            CanMove = false;
            Position = targetPosition;
            EmitSignal(SignalName.TurnFinished, this);
        }

        public override void _Ready()
        {
            Stats = (Stats) baseStats.Duplicate(true);
            Stats += Inventory.StatIncrease;
            base._Ready();
        }
    }
}