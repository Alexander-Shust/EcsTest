using Components;
using Leopotam.EcsLite;

namespace Systems
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var mouseEventPool = world.GetPool<MouseButtonEvent>();
            var movablePool = world.GetPool<Movable>();
            var mouseEventFilter = world.Filter<MouseButtonEvent>().End();
            var playerFilter = world.Filter<PlayerComponent>().End();
            foreach (var mouseEventEntity in mouseEventFilter)
            {
                foreach (var playerEntity in playerFilter)
                {
                    ref var movablePlayer = ref movablePool.Get(playerEntity);
                    movablePlayer.IsIdle = false;
                    movablePlayer.Destination = mouseEventPool.Get(mouseEventEntity).ClickPosition;
                }
            }
        }
    }
}