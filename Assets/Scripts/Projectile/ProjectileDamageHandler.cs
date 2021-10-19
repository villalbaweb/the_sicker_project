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
        BaseStats _baseStats;

        private void Awake() 
        {
            _visualEffectHandler = GetComponent<VisualEffectHandler>();
            _baseStats = GetComponent<BaseStats>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            DealDamage(collision.gameObject.GetComponent<Health>());
            
            _visualEffectHandler.ExplosionVfx(transform.position);
        }

        private void DealDamage(Health targetHealth)
        {
            if (targetHealth)
            {
                int damage = _baseStats ? (int)_baseStats.GetStat(Stat.Damage) : defaultDamage;
                targetHealth.TakeDamage(damage);
            }
        }
    }
}
