using TheSicker.Core;
using TheSicker.Stats;
using UnityEngine;
using UnityEngine.Events;

namespace TheSicker.Attacks
{
    public class FollowOnDistanceExplosiveSpecialAttack : MonoBehaviour
    {
        // config
        [SerializeField] int defaultExplosionDamage = 50;
        [SerializeField] UnityEvent onExplosionAttack = null;

        // cache
        BaseStats _baseStats;

        private void Awake()
        {
            _baseStats = GetComponent<BaseStats>();
        }

        private void OnCollisionEnter2D(Collision2D other) 
        {
            if(other.gameObject.tag != "Player") return;

            int damage = _baseStats ? (int)_baseStats.GetStat(Stat.Damage) : defaultExplosionDamage;
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            onExplosionAttack?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
