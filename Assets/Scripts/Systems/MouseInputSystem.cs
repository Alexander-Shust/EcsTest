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
                var buttons = world.GetPool<MouseButtonEvent>();
                ref var button = ref buttons.Add(entity);
                var mousePosition = Input.mousePosition;
                button.ClickPosition = camera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, -camera.transform.position.z));
            }
        }
    }
}