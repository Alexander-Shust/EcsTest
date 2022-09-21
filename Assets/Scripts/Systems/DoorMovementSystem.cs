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
            var movablePool = world.GetPool<Movable>();
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
                ref var movableDoor = ref movablePool.Get(doorEntity);
                movableDoor.IsFrozen = !activeButtons.Contains(door.Id);
            }
        }
    }
}