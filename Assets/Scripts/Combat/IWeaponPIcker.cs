using UnityEngine;

namespace TheSicker.Combat
{
    public interface IWeaponPIcker
    {
        void EquipWeapon(Weapon newWeapon);
        void PlayWeaponPickupParticles(ParticleSystem particles);
    }
}
