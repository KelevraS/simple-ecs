using UnityEngine;

namespace Client.Scripts.Contexts
{
    public class SceneContext : MonoBehaviour
    {
        [SerializeField] private Transform playerSpawnPoint;
        public Transform PlayerSpawnPoint => playerSpawnPoint;
        
        [SerializeField]
        private Camera mainCamera;
        public Camera MainCamera => mainCamera;
    }
}
