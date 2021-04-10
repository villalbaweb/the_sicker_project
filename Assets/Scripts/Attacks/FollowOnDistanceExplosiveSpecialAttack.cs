using TheSicker.Core;
using UnityEngine;

namespace TheSicker.Attacks
{
    public class FollowOnDistanceExplosiveSpecialAttack : MonoBehaviour
    {
        // config
        [SerializeField] int explosionDamage = 50;

        // cache
        DieHandler _dieHandler;

        private void Awake() 
        {
            _dieHandler = GetComponent<DieHandler>();    
        }

        private void OnCollisionEnter2D(Collision2D other) 
        {
            if(other.gameObject.tag != "Player") return;

            other.gameObject.GetComponent<Health>().TakeDamage(explosionDamage);
            _dieHandler.Die();
        }
    }
}
