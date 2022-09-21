using Components;
using Leopotam.EcsLite;
using UnityEngine;

namespace Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            var playerGo = GameObject.FindWithTag("Player");
            if (playerGo == null)
            {
                Debug.LogError("No player GO found!");
                return;
            }
            
            var world = systems.GetWorld();
            var playerPool = world.GetPool<PlayerComponent>();
            var movablePool = world.GetPool<Movable>();
            var triggerPool = world.GetPool<ButtonTriggerComponent>();
            
            var playerEntity = world.NewEntity();
            playerPool.Add(playerEntity);
            triggerPool.Add(playerEntity);
            ref var movable = ref movablePool.Add(playerEntity);
            movable.Transform = playerGo.transform;
            movable.Position = movable.Transform.position;
            movable.Destination = movable.Position;
            movable.Rotation = Quaternion.identity;
            movable.MoveSpeed = 5.0f;
            movable.RotateSpeed = 5.0f;
            movable.IsFrozen = false;
        }
    }
}