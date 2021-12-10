using UnityEngine;

namespace Client.Scripts.Contexts
{
    [CreateAssetMenu]
    public class ProjectContext : ScriptableObject
    {
        public GameObject playerPrefab;
        public float playerSpeed;
        
        public float smoothTime; 
        public Vector3 followOffset;

        public GameObject projectilePrefab;
        public float projectileRadius;
    }
}
