using System;
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

        // properties
        public int CurrentHealth => health;

        // events
        public Action OnHealthChange;

        private void Awake() 
        {
            initialHealth = health;
            OnHealthChange?.Invoke();   
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            OnHealthChange?.Invoke();

            if(health <= Mathf.Epsilon) 
            {
                onDieEvent.Invoke();
            }
        }

        public void RestoreInitialHealth()
        {
            health = initialHealth;
            OnHealthChange?.Invoke();
        }
    }
}
