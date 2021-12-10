using Client.Scripts.Components;
using Client.Scripts.Contexts;
using Client.Scripts.Views;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client.Scripts.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private EcsWorld ecsWorld;
        
        private ProjectContext projectContext; 
        private SceneContext sceneContext;

        public void Init()
        {
            EcsEntity playerEntity = ecsWorld.NewEntity();

            ref var player = ref playerEntity.Get<PlayerComponent>();
            ref var inputData = ref playerEntity.Get<PlayerInputData>();
        
            GameObject playerGO = Object.Instantiate(projectContext.playerPrefab, sceneContext.PlayerSpawnPoint.position, Quaternion.identity);
            PlayerView playerView = playerGO.GetComponent<PlayerView>();
            
            player.Rigidbody = playerView.Rigidbody;
            player.PlayerTransform = playerView.Transform;
            player.PlayerSpeed = projectContext.playerSpeed;

            ref var hasWeapon = ref playerEntity.Get<HasWeapon>();

            var weaponEntity = ecsWorld.NewEntity();
            var weaponView = playerView.WeaponView;

            ref var weapon = ref weaponEntity.Get<Weapon>();

            weapon.Owner = playerEntity;
            weapon.ProjectilePrefab = weaponView.projectilePrefab;
            weapon.ProjectileSocket = weaponView.projectileSocket;
            weapon.ProjectileSpeed = weaponView.projectileSpeed;

            hasWeapon.Weapon = weaponEntity;
        }
    }
}
