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
        [Export] public Stats Stats;
        [Export] public int CastRange;
        [Export] public int Range;
        [Export] public Godot.Collections.Array<Stats> Moves;
    }
}