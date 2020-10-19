using TheSicker.Core;
using UnityEngine;
using UnityEngine.Events;

namespace TheSicker.Projectile
{
    public class ProjectileDamageHandler : MonoBehaviour
    {
        // config
        [SerializeField] int damage = 0;
        [SerializeField] UnityEvent onHit;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            onHit.Invoke();

            DealDamage(collision.gameObject.GetComponent<Health>());
            
            gameObject.SetActive(false);
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
