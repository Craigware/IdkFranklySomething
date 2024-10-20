using Entities;
using Godot;

namespace World
{
    public partial class CameraSystem : Node
    {
        public Camera3D Current;
        public Camera3D MainCam;
        public Vector3 FollowDist = new(0, 15, 10);
        public Node3D Target;

        public override void _Ready()
        {
            CallDeferred("Init");
        }

        public void Init()
        {
            MainCam = GetNode<Camera3D>("/root/Main/Cameras/Main");
            var AllyEContainer = GetNode<Node>("/root/Main/Entities/Ally");
            foreach (var e in AllyEContainer.GetChildren())
            {
                if (e is Player p) Target = p;
            }
        }

        public override void _Process(double delta)
        {
            MainCam.Position = Target.Position + FollowDist;
            MainCam.LookAt(Target.Position);
        }

        public void SwapCamera(Camera3D newCam)
        {
        }
    }
}