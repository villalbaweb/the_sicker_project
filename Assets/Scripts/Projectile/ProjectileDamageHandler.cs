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
            // cause damage to enemies

            Health _targetHealth = collision.gameObject.GetComponent<Health>();

            if(_targetHealth)
            {
                _targetHealth.TakeDamage(damage);
            }

            gameObject.SetActive(false);
        }
    }
}
