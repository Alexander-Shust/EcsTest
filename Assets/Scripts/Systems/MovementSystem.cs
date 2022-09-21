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
            foreach (var movableEntity in movableFilter)
            {
                ref var movable = ref movablePool.Get(movableEntity);
                if (movable.IsFrozen) continue;

                var direction = Vector3.Normalize(movable.Destination - movable.Position);
                movable.Position += direction * movable.MoveSpeed * Time.deltaTime;
                movable.Transform.localPosition = movable.Position;
            }
        }
    }
}