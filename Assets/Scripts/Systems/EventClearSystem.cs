using Components;
using Leopotam.EcsLite;

namespace Systems
{
    public class EventClearSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var buttonEventFilter = world.Filter<ActiveButtonEvent>().End();
            var buttonEventPool = world.GetPool<ActiveButtonEvent>();
            foreach (var buttonEventEntity in buttonEventFilter)
            {
                buttonEventPool.Del(buttonEventEntity);
            }
        }
    }
}