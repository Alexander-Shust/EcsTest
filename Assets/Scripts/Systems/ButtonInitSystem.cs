using Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems
{
    public class ButtonInitSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            var buttons = Object.FindObjectsOfType<DoorButton>();
            if (buttons.Length == 0) return;
            
            var world = systems.GetWorld();
            var buttonPool = world.GetPool<ButtonComponent>();
            var colors = systems.GetShared<GameConfig>().Colors;
            foreach (var button in buttons)
            {
                var buttonColor = Color.black;
                if (colors.TryGetValue(button.Id, out var color))
                {
                    buttonColor = color;
                }
                button.GetComponent<Renderer>().material.color = buttonColor;
                
                var buttonEntity = world.NewEntity();
                ref var buttonComponent = ref buttonPool.Add(buttonEntity);
                buttonComponent.Id = button.Id;
                buttonComponent.Center = button.Center;
                buttonComponent.Radius = button.Radius;
            }
        }
    }
}