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
            if (playerGo == null) return;
            
            var world = systems.GetWorld();
            var playerPool = world.GetPool<PlayerComponent>();
            var movablePool = world.GetPool<Movable>();
            var rotatablePool = world.GetPool<Rotatable>();
            var renderablePool = world.GetPool<Renderable>();
            var idlePool = world.GetPool<Idle>();
            var triggerPool = world.GetPool<ButtonTriggerComponent>();
            var config = systems.GetShared<GameConfig>();
            var playerEntity = world.NewEntity();
            ref var player = ref playerPool.Add(playerEntity);
            player.PlayerAnimator = playerGo.GetComponent<Animator>();
            triggerPool.Add(playerEntity);
            idlePool.Add(playerEntity);
            
            ref var renderable = ref renderablePool.Add(playerEntity);
            renderable.Transform = playerGo.transform;
            
            ref var movable = ref movablePool.Add(playerEntity);
            movable.Position = renderable.Transform.position;
            movable.Destination = movable.Position;
            movable.MoveSpeed = config.PlayerMoveSpeed;

            ref var rotatable = ref rotatablePool.Add(playerEntity);
            rotatable.Rotation = playerGo.transform.rotation;
            rotatable.TargetRotation = rotatable.Rotation;
            rotatable.RotateSpeed = config.PlayerRotateSpeed;
        }
    }
}