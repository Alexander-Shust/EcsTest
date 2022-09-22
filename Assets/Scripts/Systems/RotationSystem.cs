using Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems
{
    public class RotationSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var world = systems.GetWorld();
            var rotatablePool = world.GetPool<Rotatable>();
            var rotatableFilter = world.Filter<Rotatable>().Exc<Idle>().End();
            foreach (var rotatableEntity in rotatableFilter)
            {
                ref var rotatable = ref rotatablePool.Get(rotatableEntity);
                rotatable.Rotation = Quaternion.Lerp(rotatable.Rotation, rotatable.TargetRotation, rotatable.RotateSpeed * Time.deltaTime);
                rotatable.Transform.rotation = rotatable.Rotation;
            }
        }
    }
}