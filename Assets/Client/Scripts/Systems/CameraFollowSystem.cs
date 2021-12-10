using Client.Scripts.Components;
using Client.Scripts.Contexts;
using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.Systems
{
    public class CameraFollowSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerComponent> filter;
        private SceneContext sceneContext;
        private ProjectContext projectContext;

        private Vector3 currentVelocity; 

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var player = ref filter.Get1(i);
            
                var currentPos = sceneContext.MainCamera.transform.position;
                currentPos = Vector3.SmoothDamp(currentPos, player.PlayerTransform.position + projectContext.followOffset, ref currentVelocity, projectContext.smoothTime);
                sceneContext.MainCamera.transform.position = currentPos;
            }
        }
    }
}