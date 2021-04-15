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

        // cache
        // DieHandler _dieHandler;

        // private void Awake()
        // {
        //     _dieHandler = GetComponent<DieHandler>();
        // }

        private void OnCollisionEnter2D(Collision2D other) 
        {
            if(other.gameObject.tag != "Player") return;

            other.gameObject.GetComponent<Health>().TakeDamage(explosionDamage);
            //_dieHandler.Die();
            onExplosionAttack?.Invoke();    // this will invoke a few SFX
        }
    }
}
