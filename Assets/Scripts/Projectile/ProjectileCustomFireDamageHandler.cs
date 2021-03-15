using System.Collections.Generic;
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
        ParticleSystem _projectileParticleSystem;

        // state
        public List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

        private void Awake() 
        {
            _projectileParticleSystem = GetComponent<ParticleSystem>();    
        }

        // This function is being trigger by any particle system with collision
        // and send messages enable, other is the object receiving the impact
        private void OnParticleCollision(GameObject other)
        {
            HandleDamage(other);
            
            CollisionParticlePlay(other);
        }

        private void HandleDamage(GameObject other)
        {
            _health = other?.GetComponent<Health>();

            _health?.TakeDamage(particleSystemDamage);
        }

        private void CollisionParticlePlay(GameObject other)
        {
            if(!collisionParticles || !_projectileParticleSystem) return;

            int numCollisionEvents = _projectileParticleSystem.GetCollisionEvents(other, collisionEvents);

            foreach (ParticleCollisionEvent collisionEvent in collisionEvents)
            {
                ParticleSystem collisionParticleSystemInstance = Instantiate(collisionParticles);
                collisionParticleSystemInstance.transform.position = collisionEvent.intersection;
                collisionParticleSystemInstance.Play();
            }

            collisionParticles.Play();
        }
    }
}
