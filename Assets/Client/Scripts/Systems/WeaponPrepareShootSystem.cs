using Client.Scripts.Components;
using Leopotam.Ecs;

namespace Client.Scripts.Systems
{
    public class WeaponPrepareShootSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerComponent, PlayerInputData> filter;
        public void Run()
        {
            foreach (var i in filter)
            {
                ref var player = ref filter.Get1(i);
                ref var input = ref filter.Get2(i);

                if (input.ShootInput)
                {
                    ref var playerEntity = ref filter.GetEntity(i);
                    playerEntity.Get<HasWeapon>().Weapon.Get<Shoot>();
                }
            }
        }
    }
}