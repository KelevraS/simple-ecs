using Client.Scripts.Components;
using Client.Scripts.Contexts;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.Systems
{
    public class ProjectileMoveSystem : IEcsRunSystem
    {
        private EcsFilter<Projectile> filter;
        private ProjectContext projectContext;
    
        public void Run()
        {
            foreach (var i in filter)
            {
                ref var projectile = ref filter.Get1(i);
            
                var position = projectile.ProjectileGo.transform.position;
                position += projectile.Direction * projectile.Speed * Time.deltaTime;
                projectile.ProjectileGo.transform.position = position;
            
                var displacementSinceLastFrame = position - projectile.PreviousPos;
                var hit = Physics.SphereCast(projectile.PreviousPos, projectContext.projectileRadius,
                    displacementSinceLastFrame.normalized, out var hitInfo, displacementSinceLastFrame.magnitude);
                if (hit)
                {
                    ref var entity = ref filter.GetEntity(i);
                    ref var projectileHit = ref entity.Get<ProjectileHit>();
                    projectileHit.RaycastHit = hitInfo;
                }

                projectile.PreviousPos = projectile.ProjectileGo.transform.position;
            }
        }
    }
}