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

        [Header("Target Control")]
        [SerializeField] LayerMask enemyLayers = new LayerMask();
        [SerializeField] float circleRayCastRadious = 0.5f;

        // State
        GameObject _projectileParent;
        Coroutine _firingCoroutine;
        bool isDead;
        bool isCustomFiring;

        // cache
        ObjectPooler _objectPooler;

        private void Awake() 
        {
            _objectPooler = FindObjectOfType<ObjectPooler>();
            selectedWeapon?.SetupWeapon(transform, _objectPooler);    
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

            RaycastHit2D raycastHit = Physics2D.CircleCast(transform.position, circleRayCastRadious, transform.right, selectedWeapon.ProjectileDistance, enemyLayers);

            return raycastHit.collider != null && IsInLayerMask(raycastHit.collider.gameObject.layer, enemyLayers);
        }

        private bool IsInLayerMask(int layer, LayerMask layermask)
        {
            return layermask == (layermask | (1 << layer));
        }

        private void StartFiring()
        {
            if(selectedWeapon.IsProjectileBased)
            {
                selectedWeapon.MuzzlerVFX?.Play();
                _firingCoroutine = _firingCoroutine != null ? _firingCoroutine : StartCoroutine(selectedWeapon.Fire(transform));
            }
            else if(!isCustomFiring)
            {
                isCustomFiring = true;
                selectedWeapon.StartCustomFire();
            }
        }

        private void StopFiring()
        {
            if (selectedWeapon.IsProjectileBased && _firingCoroutine != null)
            {
                selectedWeapon.MuzzlerVFX?.Stop();
                StopCoroutine(_firingCoroutine);
                _firingCoroutine = null;
            }
            else if (isCustomFiring)
            {
                isCustomFiring = false;
                selectedWeapon.StopCustomFire();
            }
        }

        // called from Unity Event
        public void OnDie()
        {
            isDead = true;
        }
    }
}
