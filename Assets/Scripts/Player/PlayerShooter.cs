using System.Collections;
using TheSicker.Projectile;
using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerShooter : MonoBehaviour
    {
        // config
        [SerializeField] GameObject projectile = null;
        [SerializeField] float projectileFiringPeriod = 0.1f;
        [SerializeField] float projectileDistance = 20f;
        [SerializeField] LayerMask enemyLayers;

        // State
        GameObject _projectileParent;
        Coroutine _firingCoroutine;

        const string PROJECTILE_PARENT_NAME = "Player Projectiles";

        // Start is called before the first frame update
        void Start()
        {
            CreateProjectileParent();
        }

        private void CreateProjectileParent()
        {
            _projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);

            if (!_projectileParent)
            {
                _projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
            }
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
            if (!projectile) return;

            ProjectileMovement projectileInstance = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<ProjectileMovement>();
            projectileInstance.SetRotation(transform.rotation);
            projectileInstance.transform.parent = _projectileParent.transform;
        }
    }
}
