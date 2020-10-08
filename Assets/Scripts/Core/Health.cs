using UnityEngine;

namespace TheSicker.Core
{
    public class Health : MonoBehaviour
    {
        // config
        [SerializeField] int health = 100;

        public void TakeDamage(int damage)
        {
            health -= damage;

            if(health <= Mathf.Epsilon) Die();
        }

        private void Die()
        {
            // signal the entity dead

            gameObject.SetActive(false);
        }
    }
}
