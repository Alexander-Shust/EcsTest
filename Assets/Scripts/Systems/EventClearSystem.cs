using Components;
using Leopotam.EcsLite;

namespace Systems
{
    public class EventClearSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var mouseEventFilter = world.Filter<MouseButtonEvent>().End();
            var buttonEventFilter = world.Filter<ActiveButtonEvent>().End();
            var mouseEventPool = world.GetPool<MouseButtonEvent>();
            var buttonEventPool = world.GetPool<ActiveButtonEvent>();
            
            foreach (var buttonEventEntity in buttonEventFilter)
            {
                buttonEventPool.Del(buttonEventEntity);
            }

            foreach (var mouseEventEntity in mouseEventFilter)
            {
                mouseEventPool.Del(mouseEventEntity);
            }
        }
    }
}