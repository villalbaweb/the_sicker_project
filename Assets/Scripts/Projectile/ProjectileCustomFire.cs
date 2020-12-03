using UnityEngine;

namespace TheSicker.Projectile
{
    public class ProjectileCustomFire : MonoBehaviour, IProjectileCustomFire
    {
        // config
        [SerializeField] ParticleSystem[] particleSystems = null;

        // state
        bool hasToPlay;

        #region Public Methods

        public void FireStart()
        {
            foreach(ParticleSystem particles in particleSystems)
            {
                if(!particles.isPlaying)
                {
                    particles.Play();
                }
            }
        }

        public void FireStop()
        {
            foreach (ParticleSystem particles in particleSystems)
            {
                if (particles.isPlaying)
                {
                    particles.Stop();
                }
            }
        }

        #endregion

        #region Private Methods

        private void ParticleSystemsPlay(bool play)
        {
            foreach (ParticleSystem particleSystem in particleSystems)
            {
                hasToPlay = play && !particleSystem.isPlaying ? true : false;

                if (hasToPlay)
                {
                    particleSystem.Play();
                }
                else
                {
                    particleSystem.Stop();
                }
            }
        }

        #endregion
    }
}
