using UnityEngine;

namespace Client.Scripts.Views
{
    public class WeaponView : MonoBehaviour
    {
        public GameObject projectilePrefab;
        public Transform projectileSocket;
        public float projectileSpeed;
        public float projectileRadius;
        public int weaponDamage;
        public int currentInMagazine;
        public int maxInMagazine;
        public int totalAmmo;
    }
}
