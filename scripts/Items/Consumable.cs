using Godot;
namespace Entities
{
    public enum ConsumableType
    {
        TARGET,
        SELF_AOE,
        TARGET_AOE,
        SELF,
        SUMMON
    }

    [GlobalClass]
    public partial class Consumable : Item
    {
        [Export] public ConsumableType ConsumableType;
        [Export] public int TotalDamage;
        [Export] public float Duration;
        [Export] public int Range;
    }
}