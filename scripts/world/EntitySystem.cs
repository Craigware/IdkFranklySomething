using Godot;
using Entities;

namespace World
{
    public partial class EntitySystem : Node
    {
        [Export] public Node3D Follow;
        public Area3D collector;
        public bool AllyTurn;
        public Godot.Collections.Array<Entity> Entities;
        public int EnemyCount;
        public int AllyCount;
        public int Count;
        public CameraSystem CameraSystem;

        public override void _Ready()
        {
            CallDeferred("Init");
        }

        public void Init() {
            collector = (Area3D)GetNode("/root/Main/EntityCollector");
            collector.BodyEntered += GatherEntity;
            collector.BodyExited += DropEntity;
            AllyTurn = true; // This will have to be loaded from save
            Entities = new(); // this too, well all properties really
        }

        public override void _Process(double delta)
        {
            collector.Position = Follow.Position;
        }

        public void GatherEntity(Node node)
        {
            if (node is Entity entity) {
                if (entity.Ally) AllyCount++; else EnemyCount++;
                Entities.Add(entity);
                entity.TurnFinished += IndividualTurnFinished;

                if (entity is Player p) {
                    Follow = p;
                    StartTurn(); // this is going to have to be moved later
                }
            }
        }

        public void DropEntity(Node node)
        {
            if (node is Entity entity) {
                if (entity.Ally) AllyCount--; else EnemyCount--;
                Entities.Remove(entity);
                entity.TurnFinished -= IndividualTurnFinished;
            }
        }

        public void StartTurn()
        {
            Count = 0;
            if (AllyTurn) // Allies
            {
                foreach (var entity in Entities)
                {
                    if (!entity.Ally) continue;
                    if (entity is Player p) {
                        p.CanMove = true;
                    } else {
                        entity.Move();
                    }
                }
            }
            else // Enemies
            {
                foreach (var entity in Entities)
                {
                    if (entity.Ally) continue;
                    entity.CanMove = true;
                    entity.Move();
                }
            }

            if (EnemyCount == 0 && !AllyTurn) EndTurn();
            if (AllyCount == 0) GD.Print("World Turn System: No allies??");
        }

        public void IndividualTurnFinished(Entity e)
        {
            Count++;
            if (Count == EnemyCount && !AllyTurn || Count == AllyCount && AllyTurn) {
                EndTurn();
            }
        }

        public void EndTurn()
        {
            AllyTurn = !AllyTurn;
            StartTurn();
        }
    }
}