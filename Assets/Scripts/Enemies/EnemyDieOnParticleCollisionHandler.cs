using TheSicker.Core;
using UnityEngine;

namespace TheSicker.Enemies
{
    public class EnemyDieOnParticleCollisionHandler : MonoBehaviour
    {
        // config   
        [SerializeField] int particleSystemDamage = 1000;

        // cache
        Health _health;

        // Start is called before the first frame update
        void Awake() 
        {
            _health = GetComponent<Health>();
        }

        // This function is being trigger by any particle system with collision
        // and send messages enable, so now we can kill the player with particles
        private void OnParticleCollision(GameObject other)
        {
            _health.TakeDamage(particleSystemDamage);
        }
    }
}