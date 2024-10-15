using Godot;

namespace Entities
{
    [GlobalClass]
    public partial class Player : Entity
    {
        public Player() : this(new(), true) {}
        public Player(Stats stats, bool isAlly) : base(stats, isAlly)
        {
        }


        public override void _Input(InputEvent @event)
        {
            var inputVec = Input.GetVector("Left", "Right", "Up", "Down");
            if (inputVec != Vector2.Zero && CanMove)
            {
                targetPosition = Position + new Vector3(inputVec.X, 0, inputVec.Y);
                Move();
            } 
        }

        public override void OnCol()
        {
            throw new System.NotImplementedException();
        }
    }
}