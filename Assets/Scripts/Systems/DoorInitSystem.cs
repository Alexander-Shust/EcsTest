using Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems
{
    public class DoorInitSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            var doors = Object.FindObjectsOfType<Door>();
            if (doors.Length == 0) return;
            
            var world = systems.GetWorld();
            var doorPool = world.GetPool<DoorComponent>();
            var movablePool = world.GetPool<Movable>();
            foreach (var door in doors)
            {
                var doorEntity = world.NewEntity();
                
                ref var doorComponent = ref doorPool.Add(doorEntity);
                doorComponent.Id = door.Id;
                
                ref var movable = ref movablePool.Add(doorEntity);
                movable.Transform = door.transform;
                movable.Position = movable.Transform.position;
                movable.Destination = door.Target;
                movable.Rotation = Quaternion.identity;
                movable.MoveSpeed = 0.2f;
                movable.RotateSpeed = 0.0f;
                movable.IsFrozen = true;
            }
        }
    }
}