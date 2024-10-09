using Entity;
using Godot;

namespace Save {
    public partial class Save : Resource 
    {
        [Export] Vector2 LastPos;
        [Export] Stats CurrentStats;
    }
}