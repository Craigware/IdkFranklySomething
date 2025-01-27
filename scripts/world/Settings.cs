using System;
using Godot;

namespace UI
{
    public partial class Settings : Control
    {
        [Export] private float splashTime = 3;
        private SettingResource settings = GD.Load<SettingResource>("res://resources/settings.tres");
        private SettingGUI settingsGui = null;
        private bool listening = false;

        public override void _Ready()
        {
            // Load();
            ProcessMode = Node.ProcessModeEnum.Always;
            settingsGui = GD.Load<PackedScene>("res://scenes/components/settings_gui.tscn").Instantiate<SettingGUI>();
            Timer timer = new() {
                Autostart = true,
                OneShot = true,
                WaitTime = splashTime
            };
            timer.Timeout += () => { listening = true; QueueFree(); };
            AddChild(timer);
        }

        public void Toggle() 
        {
            if (!GetTree().Paused) {
                GetNode("/root/Main/UI").AddChild(settingsGui);
                settingsGui.HideAllBut("Initial");
            } else {
                GetNode("/root/Main/UI").RemoveChild(settingsGui);
            }
            GetTree().Paused = !GetTree().Paused;
        }

        public override void _Input(InputEvent @event)
        {
            if (Input.IsActionJustPressed("Pause"))
            {
                Toggle();
            }

            if (listening) {
                SwapSceneToMain();
                listening = false;
            }
        }

        public void Save()
        {
            ResourceSaver.Save(settings);
        }

        public void Load()
        {
            //? Updateing default audio bus volume
            UpdateSoundVolume(settings.soundVolume);
            UpdateMaterVolume(settings.masterVolume);
            UpdateMusicVolume(settings.musicVolume);

            var keys = settings.keybinds.Keys;
            foreach (var key in keys) {
                InputMap.EraseAction(key);
                InputMap.ActionAddEvent(key, settings.keybinds[key]);
            }

            UpdateWindowMode(settings.windowType, settings.Borderless);
        }

        public void SwapSceneToMain() {
            GD.Print("Swapped");
            GetTree().ChangeSceneToPacked(GD.Load<PackedScene>("res://scenes/prototype.tscn"));
        }

        public void UpdateSoundVolume(float updatedVolume) {
            settings.soundVolume = updatedVolume;
            var soundBusID = AudioServer.GetBusIndex("Sound");
            float normalizedVolume = settings.soundVolume / 100.0f;
            float decibelVolume = normalizedVolume * 86 - 80;
            AudioServer.SetBusVolumeDb(soundBusID, decibelVolume);
            Save();
        }
        
        public void UpdateMaterVolume(float updatedVolume) {
            settings.masterVolume = updatedVolume;
            float normalizedVolume = settings.masterVolume / 100.0f;
            float decibelVolume = normalizedVolume * 86 - 80;
            AudioServer.SetBusVolumeDb(0, decibelVolume);
            Save();
        }
        
        public void UpdateMusicVolume(float updatedVolume) {
            settings.musicVolume = updatedVolume;
            var musicBusID = AudioServer.GetBusIndex("Music");
            float normalizedVolume = settings.musicVolume / 100.0f;
            float decibelVolume = normalizedVolume * 86 - 80;
            AudioServer.SetBusVolumeDb(musicBusID, decibelVolume);
            Save();
        }

        public void AddNewKeyBind(string inputName, InputEvent e) {
            settings.keybinds[inputName] = e;
            InputMap.EraseAction(inputName);
            InputMap.ActionAddEvent(inputName, settings.keybinds[inputName]);
            Save();
        }

        public void UpdateWindowMode(DisplayServer.WindowMode mode, bool borderless) {
            DisplayServer.WindowSetMode(mode);
            ProjectSettings.SetSetting("display/window/size/mode", (int)mode);
            ProjectSettings.SetSetting("display/window/size/borderless", borderless);
            DisplayServer.WindowSetFlag(DisplayServer.WindowFlags.Borderless, settings.Borderless);
            // ProjectSettings.Save();
        }
    }
}