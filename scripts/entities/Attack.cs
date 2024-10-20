using Godot;

namespace Entities
{
    [GlobalClass]
    public partial class Attack : Resource
    {
        [Export] public string Name;
        [Export] public string Description;
        [Export] public StatTypes ResourceType;
        [Export] public int ResourceCost;
        [Export] public EffectType EffectType;
        [Export] public int TotalDamage;
        [Export] public float Duration;
        [Export] public int Range;
    }
}