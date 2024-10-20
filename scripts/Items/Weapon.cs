using Godot;
namespace Entities
{
    public enum WeaponType
    {
        PROJECTILE,
        INSTANT,
        AOE
    }

    [GlobalClass]
    public partial class Weapon : Item
    {
        [Export] public WeaponType WeaponType;
        [Export] public Stats StatIncrease;
        [Export] public int CastRange;
        [Export] public int Range;
        [Export] public Godot.Collections.Array<Attack> Attacks;
    }
}