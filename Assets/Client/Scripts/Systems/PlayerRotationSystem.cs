using Client.Scripts.Components;
using Client.Scripts.Contexts;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.Systems
{
    public class PlayerRotationSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerComponent, PlayerInputData> filter;
        private SceneContext sceneData;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var player = ref filter.Get1(i);
                ref var input = ref filter.Get2(i);

                Plane playerPlane = new Plane(Vector3.up, player.PlayerTransform.position);
                Ray ray = sceneData.MainCamera.ScreenPointToRay(Input.mousePosition);
                if (!playerPlane.Raycast(ray, out var hitDistance)) continue;

                player.PlayerTransform.forward = ray.GetPoint(hitDistance) - player.PlayerTransform.position;
            }
        }
    }
}