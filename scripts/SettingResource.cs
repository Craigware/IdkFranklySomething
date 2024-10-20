using Godot;

namespace UI
{
    [GlobalClass]
    public partial class SettingResource : Resource
    {
        [Export] public DisplayServer.WindowMode windowType;
        [Export] public bool Borderless;
        [Export] public float masterVolume;
        [Export] public float musicVolume;
        [Export] public float soundVolume;
        [Export] public Godot.Collections.Dictionary<string, InputEvent> keybinds;
    }
} 