using Godot;

namespace Entities
{
    [GlobalClass]
    public partial class Enemy : Entity
    {
        public Enemy() : this(new(), false) {}
        public Enemy(Stats stats, bool isAlly) : base(stats, isAlly)
        {
        }
    }
}