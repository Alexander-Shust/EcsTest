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
            var rotatablePool = world.GetPool<Rotatable>();
            var idlePool = world.GetPool<Idle>();
            var config = systems.GetShared<GameConfig>();
            var colors = config.Colors;
            foreach (var door in doors)
            {
                var doorColor = Color.black;
                if (colors.TryGetValue(door.Id, out var color))
                {
                    doorColor = color;
                }
                door.GetComponent<Renderer>().material.color = doorColor;
                
                var doorEntity = world.NewEntity();
                ref var doorComponent = ref doorPool.Add(doorEntity);
                doorComponent.Id = door.Id;
                idlePool.Add(doorEntity);
                
                ref var movable = ref movablePool.Add(doorEntity);
                movable.Transform = door.transform;
                movable.Position = movable.Transform.position;
                movable.Destination = door.Target.position;
                movable.MoveSpeed = Vector3.Distance(movable.Destination, movable.Position) / door.OpenTime;

                ref var rotatable = ref rotatablePool.Add(doorEntity);
                rotatable.Transform = door.transform;
                rotatable.Rotation = rotatable.Transform.rotation;
                rotatable.TargetRotation = door.Target.rotation;
                rotatable.TargetRotation.ToAngleAxis(out var angle, out var axis);
                rotatable.RotateSpeed = angle * Mathf.Deg2Rad / door.OpenTime;
            }
        }
    }
}