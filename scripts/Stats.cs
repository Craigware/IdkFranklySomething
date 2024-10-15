using Godot;
namespace Entities
{
    [GlobalClass]
    public partial class Stats : Resource
    {
        [Export] public int Health;
        [Export] public int Armor;
    }
}