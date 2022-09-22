using Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var mouseEventPool = world.GetPool<MouseButtonEvent>();
            var movablePool = world.GetPool<Movable>();
            var rotatablePool = world.GetPool<Rotatable>();
            var idlePool = world.GetPool<Idle>();
            var mouseEventFilter = world.Filter<MouseButtonEvent>().End();
            var playerFilter = world.Filter<PlayerComponent>().End();
            foreach (var mouseEventEntity in mouseEventFilter)
            {
                foreach (var playerEntity in playerFilter)
                {
                    idlePool.Del(playerEntity);
                    
                    ref var movablePlayer = ref movablePool.Get(playerEntity);
                    movablePlayer.Destination = mouseEventPool.Get(mouseEventEntity).ClickPosition;

                    ref var rotatablePlayer = ref rotatablePool.Get(playerEntity);
                    rotatablePlayer.TargetRotation = Quaternion.LookRotation(movablePlayer.Destination - movablePlayer.Position);
                }
            }
        }
    }
}