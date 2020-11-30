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

        // properties
        public string Projectile => projectile.ToString();
        public float ProjectileFiringPeriod => projectileFiringPeriod;
        public float ProjectileDistance => projectileDistance;
        public ParticleSystem MuzzlerVFX => muzzleParticleSystem;
        public AudioClip OnFireSoundClip => onFireSoundClip;
        public float FireSoundVolume => fireSoundVolume;
        public bool IsProjectileBased => isProjectileBased;

        // cache
        ObjectPooler _objectPooler;

        #region Public Methods

        public void SetupWeapon(Transform gunPosition, ObjectPooler objectPooler)
        {
            _objectPooler = objectPooler;

            DestroyOldWeapon(gunPosition);

            if(muzzlerParticleSystemPrefab)
            {
                muzzleParticleSystem = Instantiate(muzzlerParticleSystemPrefab, gunPosition);
                muzzleParticleSystem.gameObject.name = WEAPON_NAME;
            }
        }

        public IEnumerator Fire(Transform sourceTransform)
        {
            while (true)
            {
                PlayShootSFX();
                ShootProjectile(sourceTransform);

                yield return new WaitForSeconds(projectileFiringPeriod);
            }
        }

        #endregion

        #region Private Methods

        private void ShootProjectile(Transform sourceTransform)
        {
            GameObject projectileGameObject = _objectPooler.SpawnFromPool(Projectile, sourceTransform.position, Quaternion.identity);
            ProjectileMovement projectileInstance = projectileGameObject.GetComponent<ProjectileMovement>();
            projectileInstance.SetRotation(sourceTransform.rotation);
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
