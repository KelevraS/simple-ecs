using Client.Scripts.Contexts;
using Client.Scripts.Systems;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.Services
{
    public class Startup : MonoBehaviour
    {
        [SerializeField]
        private ProjectContext projectContext;
        [SerializeField]
        private SceneContext sceneContext;
        
        private EcsWorld world;
        private EcsSystems updateSystems, fixedUpdateSystems;

        private void Start()
        {
            world = new EcsWorld();
            updateSystems = new EcsSystems(world);
            fixedUpdateSystems = new EcsSystems(world);
            RuntimeContext runtimeData = new RuntimeContext();

            updateSystems
                .Add(new PlayerInitSystem())
                .Add(new PlayerInputSystem())
                .Add(new WeaponPrepareShootSystem())
                .Add(new WeaponShootSystem())
                .Add(new SpawnProjectileSystem())
                .Add(new ProjectileMoveSystem())
                .Add(new ProjectileHitSystem())
                .Inject(projectContext)
                .Inject(sceneContext)
                .Inject(runtimeData);

            fixedUpdateSystems
                .Add(new PlayerMoveSystem())
                .Add(new PlayerRotationSystem())
                .Add(new CameraFollowSystem())
                .Inject(projectContext)
                .Inject(sceneContext)
                .Inject(runtimeData); 
      
            updateSystems.Init();
            fixedUpdateSystems.Init();
        }

        private void Update()
        {
            updateSystems?.Run();
        }

        private void FixedUpdate()
        {
            fixedUpdateSystems?.Run(); 
        }

        private void OnDestroy()
        {
            updateSystems?.Destroy();
            updateSystems = null;
            
            fixedUpdateSystems?.Destroy();
            fixedUpdateSystems = null;
            
            world?.Destroy();
            world = null;
        }
    }
}
