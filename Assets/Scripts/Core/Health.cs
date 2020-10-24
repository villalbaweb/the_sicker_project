using UnityEngine;
using UnityEngine.Events;

namespace TheSicker.Core
{
    public class Health : MonoBehaviour
    {
        // config
        [SerializeField] int health = 100;
        [SerializeField] UnityEvent<Vector2> onDieEvent;

        public void TakeDamage(int damage)
        {
            health -= damage;

            if(health <= Mathf.Epsilon) Die();
        }

        private void Die()
        {
            // signal the entity dead

            gameObject.SetActive(false);

            onDieEvent.Invoke(transform.position);
        }
    }
}
