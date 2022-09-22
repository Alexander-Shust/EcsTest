using Components;
using Leopotam.EcsLite;

namespace Systems
{
    public class RenderingSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var renderablePool = world.GetPool<Renderable>();
            var movablePool = world.GetPool<Movable>();
            var rotatablePool = world.GetPool<Rotatable>();
            var renderableFilter = world.Filter<Renderable>().End();
            foreach (var renderableEntity in renderableFilter)
            {
                ref var renderable = ref renderablePool.Get(renderableEntity);
                if (movablePool.Has(renderableEntity))
                {
                    renderable.Transform.position = movablePool.Get(renderableEntity).Position;
                }

                if (rotatablePool.Has(renderableEntity))
                {
                    renderable.Transform.rotation = rotatablePool.Get(renderableEntity).Rotation;
                }
            }
        }
    }
}