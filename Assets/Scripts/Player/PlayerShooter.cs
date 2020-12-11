using TheSicker.Combat;
using TheSicker.Core;
using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerShooter : MonoBehaviour, IWeaponPIcker
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
        bool isEquipWeaponRunning;
        Weapon currentWeapon;

        // cache
        ObjectPooler _objectPooler;

        #region  Private Methods

        private void Awake() 
        {
            _objectPooler = FindObjectOfType<ObjectPooler>();

            EquipWeapon(selectedWeapon);   
        }

        // Update is called once per frame
        void Update()
        {
            Fire();
        }

        private void Fire()
        {
            if(isEquipWeaponRunning || !currentWeapon) return;

            if (IsTargetFound())
            {
                currentWeapon.StartFiring();
            }
            else
            {
                currentWeapon.StopFiring();
            }
        }

        private bool IsTargetFound()
        {
            if (isDead) return false;

            RaycastHit2D raycastHit = Physics2D.CircleCast(transform.position, circleRayCastRadious, transform.right, currentWeapon.ProjectileDistance, enemyLayers);

            return raycastHit.collider != null && IsInLayerMask(raycastHit.collider.gameObject.layer, enemyLayers);
        }

        private bool IsInLayerMask(int layer, LayerMask layermask)
        {
            return layermask == (layermask | (1 << layer));
        }

        #endregion

        #region Public Methods

        public void EquipWeapon(Weapon newWeapon)
        {
            if(currentWeapon == newWeapon || !newWeapon) return;

            isEquipWeaponRunning = true;

            // this will kill the firing coroutine started from the weapon
            // when its a projectile based weapon
            if(currentWeapon && currentWeapon.IsProjectileBased) StopAllCoroutines();    

            currentWeapon = newWeapon;
            currentWeapon?.SetupWeapon(weaponPos ?? transform, _objectPooler, this);

            isEquipWeaponRunning = false;
        }

        // called from Unity Event
        public void OnDie()
        {
            isDead = true;
        }

        #endregion
    }
}
