using TheSicker.Core;
using UnityEngine;

namespace TheSicker.Projectile
{
    public class ProjectileDamageHandler : MonoBehaviour
    {
        // config
        [SerializeField] int damage = 0;

        private void OnTriggerEnter2D(Collider2D collision)
        {
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
