using UnityEngine;

namespace Client.Scripts.Views
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidBody;
        public Rigidbody Rigidbody => rigidBody;

        [SerializeField] private Transform transform;
        public Transform Transform => transform;

        [SerializeField] private WeaponView weaponView;
        public WeaponView WeaponView => weaponView;
    }
}
