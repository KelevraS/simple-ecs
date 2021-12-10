using Client.Scripts.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.Systems
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerComponent, PlayerInputData> filter;
    
        public void Run()
        {
            foreach (var i in filter)
            {
                ref var player = ref filter.Get1(i);
                ref var input = ref filter.Get2(i);

                Vector3 direction = (Vector3.forward * input.MovementInput.z + Vector3.right * input.MovementInput.x).normalized;
                player.Rigidbody.AddForce(direction * player.PlayerSpeed);
            }
        }
    }
}