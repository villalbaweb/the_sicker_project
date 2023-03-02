using System;
using TheSicker.Stats;
using UnityEngine;
using UnityEngine.Events;

namespace TheSicker.Core
{
    public class Health : MonoBehaviour
    {
        // config
        [SerializeField] int health = 100;
        [SerializeField] UnityEvent onDieEvent = null;

        // properties
        public float CurrentHealth => health / _initialHealth * 100;

        // events
        public Action OnHealthChange;


        // cache
        IBaseStatsGetter _baseStatsGetter;
        float _initialHealth = 0;

        private void Awake() 
        {
            _baseStatsGetter = GetComponent<IBaseStatsGetter>();

            RestoreInitialHealth();  
        }

        public void TakeDamage(int damage)
        {
            health -= damage;

            if(health <= Mathf.Epsilon) 
            {
                health = 0;
                onDieEvent.Invoke();
            }

            OnHealthChange?.Invoke();
        }

        public void RestoreInitialHealth()
        {
            health = _baseStatsGetter != null ? (int)_baseStatsGetter.GetStat(Stat.Health) : health;
            _initialHealth = health;
            OnHealthChange?.Invoke();
        }

        public void IncreaseHealth(int healthToIncrease)
        {
            int tempHealth = health + healthToIncrease;

            health = tempHealth > _initialHealth ? (int)_initialHealth : tempHealth;
            OnHealthChange?.Invoke();
        }
    }
}
