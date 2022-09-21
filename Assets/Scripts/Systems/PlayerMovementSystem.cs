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
            var buttonFilter = world.Filter<MouseButtonPressed>().End();
            var buttonPool = world.GetPool<MouseButtonPressed>();
            var movablePool = world.GetPool<Movable>();
            foreach (var buttonEntity in buttonFilter)
            {
                var playerFilter = world.Filter<PlayerComponent>().End();
                foreach (var playerEntity in playerFilter)
                {
                    ref var movablePlayer = ref movablePool.Get(playerEntity);
                    movablePlayer.Destination = buttonPool.Get(buttonEntity).ClickPosition;
                }
                buttonPool.Del(buttonEntity);
            }
        }
    }
}