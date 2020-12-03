using System.Collections;
using TheSicker.Core;
using UnityEngine;

namespace TheSicker.Projectile
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        // config
        [Header("Object Pool")]
        [SerializeField] bool isProjectileBased = true;
        [SerializeField] ObjectPoolIds projectile;

        [Header("Custom Fire")]
        [SerializeField] ProjectileCustomFire projectileCustomFirePrefab = null;

        [Header("Control")]
        [SerializeField] float projectileFiringPeriod = 0.1f;
        [SerializeField] float projectileDistance = 20f;

        [Header("VFX")]
        [SerializeField] ParticleSystem muzzlerParticleSystemPrefab = null;

        [Header("SFX")]
        [SerializeField] AudioClip onFireSoundClip = null;
        [SerializeField] [Range(0, 1)] float fireSoundVolume = 0.5f;

        // state
        const string WEAPON_NAME = "Weapon";
        ParticleSystem muzzleParticleSystem;
        ProjectileCustomFire projectileCustomFire;

        // properties
        public float ProjectileDistance => projectileDistance;

        // cache
        ObjectPooler _objectPooler;
        MonoBehaviour _weaponHoldingCharacter;

        // state
        bool isCustomFiring;
        Coroutine _firingCoroutine;

        #region Public Methods

        public void SetupWeapon(Transform gunPosition, ObjectPooler objectPooler, MonoBehaviour weaponHoldingCharacter)
        {
            _objectPooler = objectPooler;
            _weaponHoldingCharacter = weaponHoldingCharacter;

            DestroyOldWeapon(gunPosition);

            if(muzzlerParticleSystemPrefab)
            {
                muzzleParticleSystem = Instantiate(muzzlerParticleSystemPrefab, gunPosition);
                muzzleParticleSystem.gameObject.name = WEAPON_NAME;
            }

            if(projectileCustomFirePrefab)
            {
                projectileCustomFire = Instantiate(projectileCustomFirePrefab, gunPosition);
                projectileCustomFire.gameObject.name = WEAPON_NAME;
            }
        }

        public void StartFiring()
        {
            if (isProjectileBased)
            {
                muzzleParticleSystem?.Play();
                _firingCoroutine = _firingCoroutine != null ? _firingCoroutine : _weaponHoldingCharacter.StartCoroutine(Fire());
            }
            else if (!isCustomFiring)
            {
                isCustomFiring = true;
                StartCustomFire();
            }
        }

        public void StopFiring()
        {
            if (isProjectileBased && _firingCoroutine != null)
            {
                muzzleParticleSystem?.Stop();
                _weaponHoldingCharacter.StopCoroutine(_firingCoroutine);
                _firingCoroutine = null;
            }
            else if (isCustomFiring)
            {
                isCustomFiring = false;
                StopCustomFire();
            }
        }

        #endregion

        #region Private Methods

        private IEnumerator Fire()
        {
            while (true)
            {
                PlayShootSFX();
                ShootProjectile();

                yield return new WaitForSeconds(projectileFiringPeriod);
            }
        }

        private void StartCustomFire()
        {
            PlayShootSFX();
            projectileCustomFire?.FireStart();
        }

        private void StopCustomFire()
        {
            projectileCustomFire?.FireStop();
        }

        private void ShootProjectile()
        {
            GameObject projectileGameObject = _objectPooler.SpawnFromPool(projectile.ToString(), _weaponHoldingCharacter.transform.position, Quaternion.identity);
            ProjectileMovement projectileInstance = projectileGameObject?.GetComponent<ProjectileMovement>();
            projectileInstance?.SetRotation(_weaponHoldingCharacter.transform.rotation);
        }

        private void PlayShootSFX()
        {
            AudioSource.PlayClipAtPoint(onFireSoundClip, Camera.main.transform.position, fireSoundVolume);
        }

        private void DestroyOldWeapon(Transform gunPosition)
        {
            Transform oldWeapon = gunPosition.Find(WEAPON_NAME);
            if (oldWeapon)
            {
                Destroy(oldWeapon.gameObject);
            }
        }

        #endregion
    }
}
