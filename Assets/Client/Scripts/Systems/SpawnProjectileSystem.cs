using Client.Scripts.Components;
using Client.Scripts.Contexts;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.Systems
{
    public class SpawnProjectileSystem : IEcsRunSystem
    {
        private EcsFilter<Weapon, SpawnProjectile> filter;
        private EcsWorld world;
        private ProjectContext projectContext;
    
        public void Run()
        {
            foreach (var i in filter)
            {
                ref var weapon = ref filter.Get1(i);
            
                var projectileGO = Object.Instantiate(projectContext.projectilePrefab, weapon.ProjectileSocket.position, Quaternion.identity);
                
                var projectileEntity = world.NewEntity();

                ref var projectile = ref projectileEntity.Get<Projectile>();

                projectile.Direction = weapon.ProjectileSocket.forward;
                projectile.Speed = weapon.ProjectileSpeed;
                projectile.PreviousPos = projectileGO.transform.position;
                projectile.ProjectileGo = projectileGO;

                ref var entity = ref filter.GetEntity(i);
                entity.Del<SpawnProjectile>();
            }
        }
    }
}