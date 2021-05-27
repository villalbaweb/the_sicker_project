using System.Collections;
using TheSicker.Combat;
using TheSicker.Core;
using TheSicker.Projectile;
using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerShooter : MonoBehaviour, IWeaponPIcker
    {
        // config
        [Header("Weapon Selected")]
        [SerializeField] Weapon selectedWeapon = null;
        [SerializeField] Transform weaponPos = null;

        [Header("Target Control")]
        [SerializeField] LayerMask enemyLayers = new LayerMask();
        [SerializeField] float circleRayCastRadious = 0.5f;

        // constants
        const string WEAPON_NAME = "Weapon";
        const string MUZZLER_NAME = "Muzzler";

        // State
        bool isDead;
        bool isCustomFiring;
        bool isEquipWeaponRunning;
        Weapon currentWeapon;
        ParticleSystem muzzleParticleSystem;
        ProjectileCustomFire projectileCustomFire;
        Coroutine _firingCoroutine;

        // cache
        ObjectPooler _objectPooler;
        Transform _weaponTransform;

        #region  Private Methods

        private void Awake() 
        {
            _objectPooler = FindObjectOfType<ObjectPooler>();

            EquipWeapon(selectedWeapon);   
        }

        // Update is called once per frame
        void Update()
        {
            FireHandler();
        }

        private void FireHandler()
        {
            if(isEquipWeaponRunning || !currentWeapon) return;

            if (IsTargetFound())
            {
                StartFiring();
            }
            else
            {
                StopFiring();
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

        private void StartFiring()
        {
            muzzleParticleSystem?.Play();

            if (currentWeapon.IsProjectileBased)
            {
                _firingCoroutine = _firingCoroutine != null ? _firingCoroutine : StartCoroutine(Fire());
            }
            else
            {
                StartCustomFire();
            }
        }

        private IEnumerator Fire()
        {
            while (true)
            {
                PlayShootSFX();
                ShootProjectile();

                yield return new WaitForSeconds(currentWeapon.ProjectileFiringPeriod);
            }
        }

        private void PlayShootSFX()
        {
            AudioSource.PlayClipAtPoint(currentWeapon.OnFireSoundClip, Camera.main.transform.position, currentWeapon.FireSoundVolume);
        }

        private void ShootProjectile()
        {
            GameObject projectileGameObject = _objectPooler.SpawnFromPool(currentWeapon.Projectile.ToString(), _weaponTransform.position, Quaternion.identity);
            ProjectileMovement projectileInstance = projectileGameObject?.GetComponent<ProjectileMovement>();
            projectileInstance?.SetRotation(_weaponTransform.rotation);
        }

        private void StopFiring()
        {
            muzzleParticleSystem?.Stop();

            if (currentWeapon.IsProjectileBased && _firingCoroutine != null)
            {
                StopCoroutine(_firingCoroutine);
                _firingCoroutine = null;
            }
            else
            {
                StopCustomFire();
            }
        }

        private void SetupWeapon(Transform gunPosition)
        {
            _weaponTransform = gunPosition;

            DestroyOldWeapon();

            if (currentWeapon.MuzzlerParticleSystemPrefab)
            {
                muzzleParticleSystem = Instantiate(currentWeapon.MuzzlerParticleSystemPrefab, _weaponTransform);
                muzzleParticleSystem.gameObject.name = MUZZLER_NAME;
            }

            if (currentWeapon.ProjectileCustomFirePrefab)
            {
                projectileCustomFire = Instantiate(currentWeapon.ProjectileCustomFirePrefab, _weaponTransform);
                projectileCustomFire.gameObject.name = WEAPON_NAME;
            }
        }

        private void DestroyOldWeapon()
        {
            Transform oldWeapon = _weaponTransform?.Find(WEAPON_NAME);
            if (oldWeapon)
            {
                Destroy(oldWeapon.gameObject);
            }

            Transform oldMuzzler = _weaponTransform?.Find(MUZZLER_NAME);
            if (oldMuzzler)
            {
                Destroy(oldMuzzler.gameObject);
            }
        }

        private void StartCustomFire()
        {
            if (!currentWeapon.ProjectileCustomFirePrefab) return;

            projectileCustomFire?.FireStart();
        }

        private void StopCustomFire()
        {
            if(!currentWeapon.ProjectileCustomFirePrefab) return;
            
            projectileCustomFire?.FireStop();
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
            SetupWeapon(weaponPos ?? transform);

            isEquipWeaponRunning = false; 
        }

        public void PlayWeaponPickupParticles(ParticleSystem particles)
        {
            ParticleSystem weaponPickedUpParticleSystem = Instantiate(particles, weaponPos ?? transform);
            weaponPickedUpParticleSystem.Play();
        }

        // called from Unity Event
        public void OnDie()
        {
            isDead = true;
        }

        #endregion

        #region Gizmoz Area

        // called by Unity
        private void OnDrawGizmosSelected()
        {
            if(!selectedWeapon) return;
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, selectedWeapon.ProjectileDistance);
        }

        #endregion
    }
}
