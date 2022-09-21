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
            foreach (var entity in movableFilter)
            {
                ref var movable = ref movablePool.Get(entity);
                movable.Position = Vector3.Lerp(movable.Position, movable.Destination, movable.MoveSpeed * Time.deltaTime);
                movable.Transform.localPosition = movable.Position;
            }
        }
    }
}