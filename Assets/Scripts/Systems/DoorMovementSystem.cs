using System.Collections.Generic;
using Components;
using Leopotam.EcsLite;

namespace Systems
{
    public class DoorMovementSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var doorPool = world.GetPool<DoorComponent>();
            var idlePool = world.GetPool<Idle>();
            var activeButtonPool = world.GetPool<ActiveButtonEvent>();
            var activeButtonFilter = world.Filter<ActiveButtonEvent>().End();
            var doorFilter = world.Filter<DoorComponent>().End();
            var activeButtons = new List<int>();
            foreach (var activeButtonEntity in activeButtonFilter)
            {
                var activeButton = activeButtonPool.Get(activeButtonEntity);
                if (!activeButtons.Contains(activeButton.Id))
                {
                    activeButtons.Add(activeButton.Id);
                }
            }
            foreach (var doorEntity in doorFilter)
            {
                var door = doorPool.Get(doorEntity);
                if (activeButtons.Contains(door.Id))
                {
                    idlePool.Del(doorEntity);
                }
                else if (!idlePool.Has(doorEntity))
                {
                    idlePool.Add(doorEntity);
                }
            }
        }
    }
}