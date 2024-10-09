using Godot;

namespace UI
{
    [GlobalClass]
    public partial class SettingResource : Resource
    {
        [Export] public DisplayServer.WindowMode windowType;
        [Export] public bool Borderless;
        [Export] public int masterVolume;
        [Export] public int musicVolume;
        [Export] public int soundVolume;
        [Export] public Godot.Collections.Dictionary<string, InputEvent> keybinds;
    }
} 