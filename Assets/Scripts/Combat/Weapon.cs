﻿using System.Collections;
using TheSicker.Core;
using TheSicker.Projectile;
using UnityEngine;

namespace TheSicker.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        // config
        [Header("Object Pool")]
        [SerializeField] bool isProjectileBased = true;
        [SerializeField] ObjectPoolIds projectile = ObjectPoolIds.PlayerProjectile;

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
        const string MUZZLER_NAME = "Muzzler";
        ParticleSystem muzzleParticleSystem;
        ProjectileCustomFire projectileCustomFire;

        // properties
        public float ProjectileDistance => projectileDistance;
        public bool IsProjectileBased => isProjectileBased;

        // cache
        ObjectPooler _objectPooler;
        MonoBehaviour _weaponHoldingCharacter;
        Transform _weaponTransform;

        // state
        Coroutine _firingCoroutine;

        #region Public Methods

        public void SetupWeapon(Transform gunPosition, ObjectPooler objectPooler, MonoBehaviour weaponHoldingCharacter)
        {
            _objectPooler = objectPooler;
            _weaponHoldingCharacter = weaponHoldingCharacter;
            _weaponTransform = gunPosition;

            DestroyOldWeapon();

            if(muzzlerParticleSystemPrefab)
            {
                muzzleParticleSystem = Instantiate(muzzlerParticleSystemPrefab, _weaponTransform);
                muzzleParticleSystem.gameObject.name = MUZZLER_NAME;
            }

            if(projectileCustomFirePrefab)
            {
                projectileCustomFire = Instantiate(projectileCustomFirePrefab, _weaponTransform);
                projectileCustomFire.gameObject.name = WEAPON_NAME;
            }
        }

        public void StartFiring()
        {
            muzzleParticleSystem?.Play();

            if (isProjectileBased)
            {
                _firingCoroutine = _firingCoroutine != null ? _firingCoroutine : _weaponHoldingCharacter.StartCoroutine(Fire());
            }
            else
            {
                StartCustomFire();
            }
        }

        public void StopFiring()
        {
            muzzleParticleSystem?.Stop();

            if (isProjectileBased && _firingCoroutine != null)
            {
                _weaponHoldingCharacter.StopCoroutine(_firingCoroutine);
                _firingCoroutine = null;
            }
            else
            {
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
            projectileCustomFire?.FireStart();
        }

        private void StopCustomFire()
        {
            projectileCustomFire?.FireStop();
        }

        private void ShootProjectile()
        {
            GameObject projectileGameObject = _objectPooler.SpawnFromPool(projectile.ToString(), _weaponTransform.position, Quaternion.identity);
            ProjectileMovement projectileInstance = projectileGameObject?.GetComponent<ProjectileMovement>();
            projectileInstance?.SetRotation(_weaponTransform.rotation);
        }

        private void PlayShootSFX()
        {
            AudioSource.PlayClipAtPoint(onFireSoundClip, Camera.main.transform.position, fireSoundVolume);
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

        #endregion
    }
}
