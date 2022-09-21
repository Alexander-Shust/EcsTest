using System;
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
        _systems = new EcsSystems(_world);
        _systems
            .Add(new PlayerInitSystem())
            .Add(new ButtonInitSystem())
            .Add(new DoorInitSystem())
            
            .Add(new MouseInputSystem())
            .Add(new PlayerMovementSystem())
            .Add(new MovementSystem())
            .Add(new ButtonTriggerSystem())
            .Add(new DoorMovementSystem())
                
            // register additional worlds here, for example:
            // .AddWorld (new EcsWorld (), "events")
#if UNITY_EDITOR
            // add debug systems for custom worlds here, for example:
            // .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ("events"))
            .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
            .Init();
        
        _lateSystems = new EcsSystems(_world);
        _lateSystems
            .Add(new EventClearSystem())
            .Init();
    }

    private void Update() 
    {
        // process systems here.
        _systems?.Run();
    }

    private void LateUpdate()
    {
        _lateSystems.Run();
    }

    private void OnDestroy() 
    {
        if (_systems != null) 
        {
            // list of custom worlds will be cleared
            // during IEcsSystems.Destroy(). so, you
            // need to save it here if you need.
            _systems.Destroy();
            _systems = null;
        }
            
        // cleanup custom worlds here.
            
        // cleanup default world.
        if (_world != null) 
        {
            _world.Destroy();
            _world = null;
        }
    }
}