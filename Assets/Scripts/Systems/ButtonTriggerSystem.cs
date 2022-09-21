using System.Collections.Generic;
using Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems
{
    public class ButtonTriggerSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var buttonPool = world.GetPool<ButtonComponent>();
            var movablePool = world.GetPool<Movable>();
            var buttonEventPool = world.GetPool<ActiveButtonEvent>();
            var buttonFilter = world.Filter<ButtonComponent>().End();
            var triggerFilter = world.Filter<ButtonTriggerComponent>().End();
            var triggers = new List<Vector3>();
            
            foreach (var triggerEntity in triggerFilter)
            {
                var movableTrigger = movablePool.Get(triggerEntity);
                triggers.Add(movableTrigger.Position);
            }
            
            foreach (var buttonEntity in buttonFilter)
            {
                var button = buttonPool.Get(buttonEntity);
                if (ButtonTriggered(button, triggers))
                {
                    Debug.LogError(button.Id);
                    var activeButtonEntity = world.NewEntity();
                    ref var activeButtonEvent = ref buttonEventPool.Add(activeButtonEntity);
                    activeButtonEvent.Id = button.Id;
                }
            }
        }

        private bool ButtonTriggered(ButtonComponent button, List<Vector3> triggers)
        {
            var buttonCenter = new Vector2(button.Center.x, button.Center.z);
            var radius = button.Radius;
            foreach (var trigger in triggers)
            {
                var triggerCenter = new Vector2(trigger.x, trigger.z);
                var distance = Vector2.Distance(triggerCenter, buttonCenter);
                if (distance < radius) return true;
            }
            return false;
        }
    }
}