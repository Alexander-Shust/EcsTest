using Components;
using Leopotam.EcsLite;

namespace Systems
{
    public class PlayerAnimationSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var idlePool = world.GetPool<Idle>();
            var playerPool = world.GetPool<PlayerComponent>();
            var playerFilter = world.Filter<PlayerComponent>().End();
            foreach (var playerEntity in playerFilter)
            {
                var player = playerPool.Get(playerEntity);
                var animator = player.PlayerAnimator;
                animator.SetBool("Moving", !idlePool.Has(playerEntity));
            }
        }
    }
}