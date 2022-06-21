using TheSicker.Core;
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
        FollowOnDistanceTouchAttackProvider _followOnDistanceTouchAttackProvider;

        private void Awake()
        {
            _followOnDistanceTouchAttackProvider = GetComponent<FollowOnDistanceTouchAttackProvider>();
        }

        private void OnCollisionEnter2D(Collision2D other) 
        {
            if(other.gameObject.tag != "Player") return;

            int damage = _followOnDistanceTouchAttackProvider ? _followOnDistanceTouchAttackProvider.GetTouchAttackDamage() : defaultExplosionDamage;
            other.gameObject.GetComponent<Health>().TakeDamage(damage);
            onExplosionAttack?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
