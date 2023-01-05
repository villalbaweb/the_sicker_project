using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerBackToLifeVisualEffectHandler : MonoBehaviour
    {
        // config
        [SerializeField] ParticleSystem pickupParticleSystem = null;

        public void PlayBackToLifeParticles()
        {
            ParticleSystem backToLifeParticleSystem = Instantiate(pickupParticleSystem, transform);
            backToLifeParticleSystem.Play();
        }
    }
}
