using Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems
{
    public class MovementSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var movablePool = world.GetPool<Movable>();
            var movableFilter = world.Filter<Movable>().End();
            var deltaTime = Time.deltaTime;
            foreach (var movableEntity in movableFilter)
            {
                ref var movable = ref movablePool.Get(movableEntity);
                movable.Rotation = Quaternion.Lerp(movable.Rotation, Quaternion.LookRotation(movable.Destination - movable.Position), movable.RotateSpeed * deltaTime);
                movable.Transform.localRotation = movable.Rotation;
                if (movable.IsIdle) continue;

                var direction = Vector3.Normalize(movable.Destination - movable.Position);
                movable.Position += direction * movable.MoveSpeed * deltaTime;
                movable.Transform.localPosition = movable.Position;
                if (Vector3.Distance(movable.Position, movable.Destination) <= 0.01f)
                {
                    movable.IsIdle = true;
                }
            }
        }
    }
}