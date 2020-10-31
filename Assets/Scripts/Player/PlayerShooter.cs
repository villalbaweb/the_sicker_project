using System.Collections;
using TheSicker.Core;
using TheSicker.Projectile;
using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerShooter : MonoBehaviour
    {
        // config
        [Header("Projectile Control")]
        [SerializeField] float projectileFiringPeriod = 0.1f;
        [SerializeField] float projectileDistance = 20f;
        [SerializeField] ParticleSystem muzzlerVFX = null;

        [Header("Projectile SFX")]
        [SerializeField] AudioClip onFireSoundClip = null;
        [SerializeField] [Range(0, 1)] float fireSoundVolume = 0.5f;

        [Header("Target Control")]
        [SerializeField] LayerMask enemyLayers = new LayerMask();
        [SerializeField] float circleRayCastRadious = 0.5f;

        // State
        GameObject _projectileParent;
        Coroutine _firingCoroutine;

        // cache
        ObjectPooler _objectPooler;

        private void Awake() 
        {
            _objectPooler = FindObjectOfType<ObjectPooler>();    
        }

        // Update is called once per frame
        void Update()
        {
            Fire();
        }

        private void Fire()
        {
            if (IsTargetFound())
            {
                muzzlerVFX.Play();
                _firingCoroutine = _firingCoroutine != null ? _firingCoroutine : StartCoroutine(Firing());
            }
            else if (_firingCoroutine != null)
            {
                muzzlerVFX.Stop();
                StopCoroutine(_firingCoroutine);
                _firingCoroutine = null;
            }
        }

        private bool IsTargetFound()
        {
            //RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, transform.right, projectileDistance, enemyLayers);
            RaycastHit2D raycastHit = Physics2D.CircleCast(transform.position, circleRayCastRadious, transform.right, projectileDistance, enemyLayers);

            return raycastHit.collider != null && IsInLayerMask(raycastHit.collider.gameObject.layer, enemyLayers);
        }

        private bool IsInLayerMask(int layer, LayerMask layermask)
        {
            return layermask == (layermask | (1 << layer));
        }

        private IEnumerator Firing()
        {
            while(true)
            {
                PlayShootSFX();
                Shoot();

                yield return new WaitForSeconds(projectileFiringPeriod);
            }
        }

        private void Shoot()
        {
            GameObject projectileGameObject = _objectPooler.SpawnFromPool("PlayerProjectile", transform.position, Quaternion.identity);
            ProjectileMovement projectileInstance = projectileGameObject.GetComponent<ProjectileMovement>();
            projectileInstance.SetRotation(transform.rotation);
        }

        private void PlayShootSFX()
        {
            AudioSource.PlayClipAtPoint(onFireSoundClip, Camera.main.transform.position, fireSoundVolume);
        }
    }
}
