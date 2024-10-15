using Godot;

namespace Entities
{
    public enum ArmorType
    {
        HAT,
        HELMET,
        CHEST,
        LEG,
        FOOT,
        ARM,
        NECK
    }

    public enum ArmorEffect
    {
        THORNS,
        HEALTH_RESTORE,
        MANA_RESTORE
    }

    [GlobalClass]
    public partial class Armor : Item
    {
        [Export] public ArmorType ArmorType;
        [Export] public Stats StatIncrease;
        [Export] public ArmorEffect ArmorEffect;
        [Export(PropertyHint.Range, "0,1")] public float Effectiveness;
        [Export] public Godot.Collections.Array<Stats> Moves;
    }
}