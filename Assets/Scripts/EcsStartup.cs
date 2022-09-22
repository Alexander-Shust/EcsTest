using Leopotam.EcsLite;
using Systems;
using UnityEngine;

public sealed class EcsStartup : MonoBehaviour 
{
    private EcsWorld _world;        
    private IEcsSystems _systems;
    private IEcsSystems _lateSystems;

    private void Start() 
    {
        _world = new EcsWorld();
        var gameConfig = new GameConfig();
        _systems = new EcsSystems(_world, gameConfig);
        _systems
            .Add(new PlayerInitSystem())
            .Add(new ButtonInitSystem())
            .Add(new DoorInitSystem())
            .Add(new TimeSystem())
            .Add(new MouseInputSystem())
            .Add(new PlayerControlSystem())
            .Add(new PlayerAnimationSystem())
            .Add(new ButtonTriggerSystem())
            .Add(new DoorActivationSystem())
            .Add(new RotationSystem())
            .Add(new MovementSystem())
            .Init();
        
        _lateSystems = new EcsSystems(_world);
        _lateSystems
            .Add(new RenderingSystem())
            .Add(new EventClearSystem())
            .Init();
    }

    private void Update() 
    {
        _systems?.Run();
    }

    private void LateUpdate()
    {
        _lateSystems?.Run();
    }

    private void OnDestroy() 
    {
        if (_systems != null) 
        {
            _systems.Destroy();
            _systems = null;
        }

        if (_lateSystems != null)
        {
            _lateSystems.Destroy();
            _lateSystems = null;
        }
        
        if (_world != null) 
        {
            _world.Destroy();
            _world = null;
        }
    }
}