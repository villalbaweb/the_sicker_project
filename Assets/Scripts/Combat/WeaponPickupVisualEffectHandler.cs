using UnityEngine;

namespace TheSicker.Combat
{
    public class WeaponPickupVisualEffectHandler : MonoBehaviour
    {
        // config
        [SerializeField] ParticleSystem[] pickupParticleSystems = null;

        public void VFXParticlesPlay()
        {
            print("Playing particle systems after pickup...");
        }
    }
}
