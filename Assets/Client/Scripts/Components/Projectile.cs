using UnityEngine;

namespace Client.Scripts.Components
{
    public struct Projectile
    {
        public Vector3 Direction;
        public float Speed;
        public float Radius;
        public Vector3 PreviousPos;
        public GameObject ProjectileGo;
    }
}