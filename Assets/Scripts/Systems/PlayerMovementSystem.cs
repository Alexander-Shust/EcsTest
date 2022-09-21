using Components;
using Leopotam.EcsLite;

namespace Systems
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var mouseEventFilter = world.Filter<MouseButtonEvent>().End();
            var mouseEventPool = world.GetPool<MouseButtonEvent>();
            var movablePool = world.GetPool<Movable>();
            foreach (var mouseEventEntity in mouseEventFilter)
            {
                var playerFilter = world.Filter<PlayerComponent>().End();
                foreach (var playerEntity in playerFilter)
                {
                    ref var movablePlayer = ref movablePool.Get(playerEntity);
                    movablePlayer.Destination = mouseEventPool.Get(mouseEventEntity).ClickPosition;
                }
                mouseEventPool.Del(mouseEventEntity);
            }
        }
    }
}