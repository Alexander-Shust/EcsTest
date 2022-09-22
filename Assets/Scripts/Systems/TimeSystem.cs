using Leopotam.EcsLite;
using UnityEngine;

namespace Systems
{
    public class TimeSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            var config = systems.GetShared<GameConfig>();
            config.DeltaTime = Time.deltaTime;
        }
    }
}