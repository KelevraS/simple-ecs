using Client.Scripts.Components;
using Leopotam.Ecs;

namespace Client.Scripts.Systems
{
    public class WeaponShootSystem : IEcsRunSystem
    {
        private EcsFilter<Weapon, Shoot> weaponFilter;
        public void Run()
        {
            foreach (var i in weaponFilter)
            {
                ref var weapon = ref weaponFilter.Get1(i);
                ref var entity = ref weaponFilter.GetEntity(i);
                ref var spawnProjectile = ref entity.Get<SpawnProjectile>();
                entity.Del<Shoot>();
            }
        }
    }
}