using TheSicker.Core;
using TheSicker.Stats;
using UnityEngine;

namespace TheSicker.Projectile
{
    public class ProjectileDamageHandler : MonoBehaviour
    {
        // config
        [SerializeField] int defaultDamage = 0;

        // cache
        VisualEffectHandler _visualEffectHandler;
        ProjectileCameraShakeController _projectileCameraShakeController;
        IBaseStatsGetter _baseStatsGetter;

        private void Awake() 
        {
            _visualEffectHandler = GetComponent<VisualEffectHandler>();
            _projectileCameraShakeController = GetComponent<ProjectileCameraShakeController>();
            _baseStatsGetter = GetComponent<IBaseStatsGetter>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            DealDamageDirectionalVfx(collision.gameObject.GetComponent<IDirectionalDamageSpawner>());
            SetLastDirectionalAttack(collision.gameObject.GetComponent<IDirectionalKeeper>());
            
            DealDamage(collision.gameObject.GetComponent<Health>());

            _visualEffectHandler.ExplosionVfx(transform.position);
            _projectileCameraShakeController.CameraShake();
        }

        private void DealDamage(Health targetHealth)
        {
            if (targetHealth)
            {
                int damage = _baseStatsGetter != null ? (int)_baseStatsGetter.GetStat(Stat.Damage) : defaultDamage;
                targetHealth.TakeDamage(damage);
            }
        }

        private void DealDamageDirectionalVfx(IDirectionalDamageSpawner directionalDamageSpawner)
        {
            if (directionalDamageSpawner == null) return;

            directionalDamageSpawner.DirectionalDamageVfxSpawn(transform.position, transform.eulerAngles);
        }

        private void SetLastDirectionalAttack(IDirectionalKeeper directionalKeeper)
        {
            if (directionalKeeper == null) return;

            directionalKeeper.StoreDirectionEulerVector(transform.eulerAngles);
        }
    }
}
