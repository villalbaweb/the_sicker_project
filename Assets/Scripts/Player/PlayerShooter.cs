using TheSicker.Core;
using TheSicker.Projectile;
using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerShooter : MonoBehaviour
    {
        // config
        [Header("Weapon Selected")]
        [SerializeField] Weapon selectedWeapon;
        [SerializeField] Transform weaponPos;

        [Header("Target Control")]
        [SerializeField] LayerMask enemyLayers = new LayerMask();
        [SerializeField] float circleRayCastRadious = 0.5f;

        // State
        bool isDead;
        bool isCustomFiring;

        // cache
        ObjectPooler _objectPooler;

        private void Awake() 
        {
            _objectPooler = FindObjectOfType<ObjectPooler>();
            selectedWeapon?.SetupWeapon(weaponPos ?? transform, _objectPooler, this);    
        }

        // Update is called once per frame
        void Update()
        {
            Fire();
        }

        private void Fire()
        {
            if(!selectedWeapon) return;

            if (IsTargetFound())
            {
                selectedWeapon.StartFiring();
            }
            else
            {
                selectedWeapon.StopFiring();
            }
        }

        private bool IsTargetFound()
        {
            if (isDead) return false;

            RaycastHit2D raycastHit = Physics2D.CircleCast(transform.position, circleRayCastRadious, transform.right, selectedWeapon.ProjectileDistance, enemyLayers);

            return raycastHit.collider != null && IsInLayerMask(raycastHit.collider.gameObject.layer, enemyLayers);
        }

        private bool IsInLayerMask(int layer, LayerMask layermask)
        {
            return layermask == (layermask | (1 << layer));
        }

        // called from Unity Event
        public void OnDie()
        {
            isDead = true;
        }
    }
}
