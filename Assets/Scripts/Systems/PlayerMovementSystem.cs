using Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var filter = world.Filter<MouseButtonPressed>().End();
            var pool = world.GetPool<MouseButtonPressed>();
            foreach (var entity in filter)
            {
                Debug.LogError("Mouse button pressed");
                pool.Del(entity);
            }
        }
    }
}