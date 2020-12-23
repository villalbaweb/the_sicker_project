using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerEngineParticleEffectsStopper : MonoBehaviour
    {
        // config
        [SerializeField] ParticleSystem[] playersParticleSystems = null;

        public void EngineParticleSystemsTurnOff()
        {
            foreach(ParticleSystem particles in playersParticleSystems)
            {
                if(particles.isPlaying)
                {
                    particles.Stop();
                }
            }
        }
    }
}