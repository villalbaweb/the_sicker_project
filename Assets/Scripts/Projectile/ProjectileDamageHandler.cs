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
        IBaseStatsGetter _baseStatsGetter;

        private void Awake() 
        {
            _visualEffectHandler = GetComponent<VisualEffectHandler>();
            _baseStatsGetter = GetComponent<IBaseStatsGetter>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            DealDamage(collision.gameObject.GetComponent<Health>());
            DealDamageDirectionalVfx(collision.gameObject.GetComponent<IDirectionalDamageSpawner>());
            
            _visualEffectHandler.ExplosionVfx(transform.position);
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
    }
}
