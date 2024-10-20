using Godot;

namespace Entities
{
    [GlobalClass]
    public partial class Player : Entity
    {
        public Player() : this(new(), true) {}
        public Player(Stats stats, bool isAlly) : base(stats, isAlly) {}

        public override void _PhysicsProcess(double delta)
        {
            var inputVec = new Vector3();
            // For some reason Input.getVector doesnt work properly with gamecube controller so we do this
            // Also I don't need normalization
            if (Input.IsActionPressed("Left")) inputVec.X -= 1;
            if (Input.IsActionPressed("Right")) inputVec.X += 1;
            if (Input.IsActionPressed("Up")) inputVec.Z -= 1;
            if (Input.IsActionPressed("Down")) inputVec.Z += 1;
            
            if (inputVec != Vector3.Zero && CanMove)
            {
                targetPosition = Position + (inputVec * 2);
                Move();
            } 

            if (Input.IsActionJustPressed("FastQuit")) GetTree().Quit();
        }
    }
}