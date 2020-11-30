using TheSicker.Core;
using UnityEngine;

namespace TheSicker.Projectile
{
    public class ProjectileDamageHandler : MonoBehaviour
    {
        // config
        [SerializeField] int damage = 0;

        // cache
        VisualEffectHandler _visualEffectHandler;

        private void Awake() 
        {
            _visualEffectHandler = GetComponent<VisualEffectHandler>();    
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
                targetHealth.TakeDamage(damage);
            }
        }
    }
}
