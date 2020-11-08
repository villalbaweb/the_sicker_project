using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerEngineParticleEffectsStopper : MonoBehaviour
    {
        // config
        [SerializeField] ParticleSystem engineParticleSystem = null;
        [SerializeField] ParticleSystem speedEngineParticleSystem = null;

        public void EngineParticleSystemsTurnOff()
        {
            if(engineParticleSystem.isPlaying)
            {
                engineParticleSystem.Stop();
            }

            if(speedEngineParticleSystem.isPlaying)
            {
                speedEngineParticleSystem.Stop();
            }
        }
    }
}