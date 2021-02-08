using UnityEngine;

namespace TheSicker.Combat
{
    public class WeaponPickupVisualEffectHandler : MonoBehaviour
    {
        // config
        [SerializeField] ParticleSystem pickupParticleSystem = null;

        public void VFXParticlesPlay(GameObject equipWeaponTo)
        {
            if(!pickupParticleSystem) return;

            IWeaponPIcker _weaponPicker = equipWeaponTo.GetComponent<IWeaponPIcker>();

            _weaponPicker.PlayWeaponPickupParticles(pickupParticleSystem);
        }
    }
}
