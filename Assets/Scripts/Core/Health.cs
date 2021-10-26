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
        public int CurrentHealth => health;

        // events
        public Action OnHealthChange;

        // cache
        IBaseStatsGetter _baseStatsGetter;

        private void Awake() 
        {
            _baseStatsGetter = GetComponent<IBaseStatsGetter>();

            OnHealthChange?.Invoke();   
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
            OnHealthChange?.Invoke();
        }

        public void IncreaseHealth(int healthToIncrease)
        {
            health += healthToIncrease;
            OnHealthChange?.Invoke();
        }
    }
}
