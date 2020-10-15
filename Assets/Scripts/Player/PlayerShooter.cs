using System.Collections;
using TheSicker.Core;
using TheSicker.Projectile;
using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerShooter : MonoBehaviour
    {
        // config
        [SerializeField] float projectileFiringPeriod = 0.1f;
        [SerializeField] float projectileDistance = 20f;
        [SerializeField] LayerMask enemyLayers = new LayerMask();

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
                _firingCoroutine = _firingCoroutine != null ? _firingCoroutine : StartCoroutine(Firing());
            }
            else if (_firingCoroutine != null)
            {
                StopCoroutine(_firingCoroutine);
                _firingCoroutine = null;
            }
        }

        private bool IsTargetFound()
        {
            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, transform.right, projectileDistance, enemyLayers);
            
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
    }
}
