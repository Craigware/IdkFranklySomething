using Godot;
using System;
using UI;

public partial class SettingGUI : Control
{
    public override void _Ready()
    {
        ProcessMode =  Node.ProcessModeEnum.Always;
    }

    public void HideAllBut(string name) {
        foreach (Control node in GetChildren())
        {
            node.Visible = false;
        }
        GetNode<Control>(name).Visible = true;
    }

    public void ShowSoundSettings() { HideAllBut("Sound"); }
    public void ShowKeybindSettings() { HideAllBut("Keybinds"); }
    public void Resume() { GetNode<Settings>("/root/Settings").Toggle(); }
    public void Quit() { GetTree().Quit(); }

    public void UpdateMasterVolume(float percent) { GetNode<Settings>("/root/Settings").UpdateMaterVolume(percent); }
    public void UpdateSoundVolume(float percent) { GetNode<Settings>("/root/Settings").UpdateSoundVolume(percent); }
    public void UpdateMusicVolume(float percent) { GetNode<Settings>("/root/Settings").UpdateMusicVolume(percent); }
}
