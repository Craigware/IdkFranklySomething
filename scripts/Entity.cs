using Godot;

namespace Entity 
{
    public partial class Stats : Resource
    {
        [Export] public int Health;
        [Export] public int Armor;
    }

    public abstract partial class Entity : CharacterBody2D
    {
        [Export] public bool Ally;
        [Export] public Stats Stats;
        [Export] private Stats baseStats;
        public abstract void Move();
        public abstract void Die();
        public abstract void OnCol();
    }
}