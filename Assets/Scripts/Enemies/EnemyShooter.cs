﻿using System.Collections;
using TheSicker.Combat;
using TheSicker.Core;
using TheSicker.Game;
using TheSicker.Projectile;
using UnityEngine;

namespace TheSicker.Enemies
{
    public class EnemyShooter : MonoBehaviour, IPooledObject
    {
        // config
        [Header("Weapon Selected")]
        [SerializeField] EnemyWeapon selectedEnemyWeapon = null;
        [SerializeField] Transform weaponPos = null;

        [Header("Target Control")]
        [SerializeField] LayerMask enemyLayers = new LayerMask();
        [SerializeField] float circleRayCastRadious = 0.5f;

        // constatnts
        const string MUZZLER_NAME = "Muzzler";

        // State
        bool isDead;
        EnemyWeapon currentWeapon;
        ParticleSystem muzzleParticleSystem; 
        Coroutine _firingCoroutine;

        // cache
        ObjectPooler _objectPooler;
        Transform _weaponTransform;
        WaitForSeconds _fireWaitForSeconds;
        GameSoundController _gameSoundController;

        #region  Private Methods

        private void Awake()
        {
            _objectPooler = FindObjectOfType<ObjectPooler>();
            _gameSoundController = FindObjectOfType<GameSoundController>();

            EquipWeapon();
        }

        // Update is called once per frame
        void Update()
        {
            FireHandler();
        }

        private void FireHandler()
        {
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

        private void EquipWeapon()
        {
            // this will kill the firing coroutine started from the weapon
            // when its a projectile based weapon
            StopAllCoroutines();

            currentWeapon = selectedEnemyWeapon;

            SetupWeapon(weaponPos ?? transform);

            _fireWaitForSeconds = new WaitForSeconds(currentWeapon.ProjectileFiringPeriod);
        }

        private void SetupWeapon(Transform gunPosition)
        {
            _weaponTransform = gunPosition;

            if (currentWeapon.MuzzlerParticleSystemPrefab)
            {
                muzzleParticleSystem = Instantiate(currentWeapon.MuzzlerParticleSystemPrefab, _weaponTransform);
                muzzleParticleSystem.gameObject.name = MUZZLER_NAME;
            }
        }

        private void StartFiring()
        {
            muzzleParticleSystem?.Play();

            _firingCoroutine = _firingCoroutine != null ? _firingCoroutine : StartCoroutine(Fire());

        }

        private void StopFiring()
        {
            muzzleParticleSystem?.Stop();

            if (_firingCoroutine != null)
            {
                StopCoroutine(_firingCoroutine);
                _firingCoroutine = null;
            }
        }

        private IEnumerator Fire()
        {
            while (true)
            {
                PlayShootSFX();
                ShootProjectile();

                yield return _fireWaitForSeconds;
            }
        }

        private void ShootProjectile()
        {
            GameObject projectileGameObject = _objectPooler.SpawnFromPool(currentWeapon.Projectile.ToString(), _weaponTransform.position, Quaternion.identity);
            ProjectileMovement projectileInstance = projectileGameObject?.GetComponent<ProjectileMovement>();
            projectileInstance?.SetRotation(_weaponTransform.rotation);
        }

        private void PlayShootSFX()
        {
            _gameSoundController?.PlayClipAtCamera(currentWeapon.OnFireSoundClip);
        }

        #endregion

        #region Public Methods

        // called from Unity Event
        public void OnDie()
        {
            isDead = true;
        }

        // execute specific action on spawn
        public void OnObjectSpawn()
        {
            isDead = false;
        }

        #endregion
    }
}
