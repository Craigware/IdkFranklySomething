using Godot;
namespace Entities
{
    public enum EffectType
    {
        TARGET,
        SELF_AOE,
        TARGET_AOE,
        SELF,
        SUMMON,
        PROJECTILE
    }

    [GlobalClass]
    public partial class Consumable : Item
    {
        [Export] public EffectType EffectType;
        [Export] public int TotalDamage;
        [Export] public float Duration;
        [Export] public int Range;
    }
}