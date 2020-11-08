using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace TheSicker.Core
{
    public class Health : MonoBehaviour
    {
        // config
        [SerializeField] int health = 100;
        [SerializeField] UnityEvent onDieEvent = null;

        // state
        int initialHealth;

        private void Awake() 
        {
            initialHealth = health;    
        }

        public void TakeDamage(int damage)
        {
            health -= damage;

            if(health <= Mathf.Epsilon) 
            {
                onDieEvent.Invoke();
            }
        }

        public void RestoreInitialHealth()
        {
            health = initialHealth;
        }
    }
}
