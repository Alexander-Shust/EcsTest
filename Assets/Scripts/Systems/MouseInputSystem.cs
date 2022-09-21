using Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems
{
    public class MouseInputSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            if (Input.GetMouseButtonUp(0))
            {
                var entity = world.NewEntity();
                var buttons = world.GetPool<MouseButtonPressed>();
                buttons.Add(entity);
            }
        }
    }
}