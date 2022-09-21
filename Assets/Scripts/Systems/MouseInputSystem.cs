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
                var camera = Camera.main;
                if (camera == null) return;
                
                var entity = world.NewEntity();
                var mouseEvents = world.GetPool<MouseButtonEvent>();
                ref var mouseEvent = ref mouseEvents.Add(entity);
                var ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hitInfo, float.MaxValue, LayerMask.GetMask("Ground")))
                {
                    mouseEvent.ClickPosition = hitInfo.point;
                }
            }
        }
    }
}