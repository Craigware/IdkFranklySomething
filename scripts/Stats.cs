using Godot;
namespace Entities
{
    public enum StatTypes {
        HEALTH,
        DEFENSE,
        WISDOM,
        INTELLIGENCE,
        STRENGTH,
        STAMINA,
        MANA
    }

    [GlobalClass]
    public partial class Stats : Resource
    {
        [Export] public int Health;
        [Export] public int Defense;
        [Export] public int Wisdom;
        [Export] public int Intelligence;
        [Export] public int Strength;
        [Export] public int Stamina;
        [Export] public int Mana;

        public static Stats operator +(Stats a, Stats b) {
            a.Health += b.Health;
            a.Defense += b.Defense;
            a.Wisdom += b.Wisdom;
            a.Intelligence += b.Intelligence;
            a.Strength += b.Strength;
            a.Stamina += b.Stamina;
            a.Mana += b.Stamina;
            return a;
        }

        public static Stats operator -(Stats a, Stats b) {
            a.Health -= b.Health;
            a.Defense -= b.Defense;
            a.Wisdom -= b.Wisdom;
            a.Intelligence -= b.Intelligence;
            a.Strength -= b.Strength;
            a.Stamina -= b.Stamina;
            a.Mana -= b.Stamina;
            return a;
        }
    }
}