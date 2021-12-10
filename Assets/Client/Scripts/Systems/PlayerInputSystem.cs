using Client.Scripts.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerInputData> filter;
        public void Run()
        {
            foreach (var i in filter)
            {
                ref var input = ref filter.Get1(i);
          
                input.MovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); 
                input.ShootInput = Input.GetMouseButtonDown(0); 
            }
        }
    }
}