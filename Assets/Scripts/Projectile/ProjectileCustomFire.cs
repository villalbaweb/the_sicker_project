using UnityEngine;

namespace TheSicker.Projectile
{
    public class ProjectileCustomFire : MonoBehaviour, IProjectileCustomFire
    {
        // config
        [SerializeField] ParticleSystem[] particleSystems = null;
        [SerializeField] AudioSource audioSource = null;

        // state
        bool hasToPlay;

        #region Public Methods

        public void FireStart()
        {
            StartPlayingSFX();

            foreach(ParticleSystem particles in particleSystems)
            {
                if(!particles.isEmitting)
                {
                    particles.Play();
                }
            }
        }

        public void FireStop()
        {
            StopPlayingSFX();

            foreach (ParticleSystem particles in particleSystems)
            {
                if (particles.isEmitting)
                {
                    particles.Stop();
                }
            }
        }

        #endregion

        #region Private Methods

        private void StartPlayingSFX()
        {
            if(!audioSource) return;

            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        private void StopPlayingSFX()
        {
            if (!audioSource) return;

            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        #endregion
    }
}
