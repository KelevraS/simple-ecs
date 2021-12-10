using Leopotam.Ecs;
using UnityEngine;

namespace Client.Scripts.Components
{
    public struct Weapon
    {
        public EcsEntity Owner;
        
        public GameObject ProjectilePrefab;
        public Transform ProjectileSocket;
        public float ProjectileSpeed;
    }
}