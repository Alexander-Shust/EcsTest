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
            var idlePool = world.GetPool<Idle>();
            var movableFilter = world.Filter<Movable>().Exc<Idle>().End();
            foreach (var movableEntity in movableFilter)
            {
                ref var movable = ref movablePool.Get(movableEntity);
                if (Vector3.Distance(movable.Position, movable.Destination) <= 0.01f)
                {
                    idlePool.Add(movableEntity);
                }
                else
                {
                    var direction = Vector3.Normalize(movable.Destination - movable.Position);
                    movable.Position += direction * movable.MoveSpeed * Time.deltaTime;
                    movable.Transform.localPosition = movable.Position;
                }
            }
        }
    }
}