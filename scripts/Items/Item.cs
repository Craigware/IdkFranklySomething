using Godot;

namespace Entities
{
    [GlobalClass]
    public partial class Item : Resource
    {
        [Export] public string Name;
        [Export] public string Description;
        [Export] public int Price;
        [Export] public bool Sellable;
        [Export] public int StackSize;
    }
}