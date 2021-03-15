using TheSicker.Core;
using UnityEngine;

namespace TheSicker.Projectile
{
    public class ProjectileCustomFireDamageHandler : MonoBehaviour
    {
        // config   
        [SerializeField] int particleSystemDamage = 1000;
        [SerializeField] ParticleSystem collisionParticles = null;

        // cache
        Health _health;

        // This function is being trigger by any particle system with collision
        // and send messages enable, other is the object receiving the impact
        private void OnParticleCollision(GameObject other)
        {
            HandleDamage(other);
            
            CollisionParticlePlay();
        }

        private void HandleDamage(GameObject other)
        {
            _health = other?.GetComponent<Health>();

            _health?.TakeDamage(particleSystemDamage);
        }

        private void CollisionParticlePlay()
        {
            if(!collisionParticles) return;

            collisionParticles.Play();
        }
    }
}
