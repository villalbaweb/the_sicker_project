using TheSicker.Core;
using UnityEngine;
using UnityEngine.Events;

namespace TheSicker.Attacks
{
    public class FollowOnDistanceExplosiveSpecialAttack : MonoBehaviour
    {
        // config
        [SerializeField] int explosionDamage = 50;
        [SerializeField] UnityEvent onExplosionAttack = null;

        private void OnCollisionEnter2D(Collision2D other) 
        {
            if(other.gameObject.tag != "Player") return;

            other.gameObject.GetComponent<Health>().TakeDamage(explosionDamage);
            onExplosionAttack?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
