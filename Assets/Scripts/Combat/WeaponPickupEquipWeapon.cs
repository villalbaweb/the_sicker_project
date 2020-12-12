using UnityEngine;

namespace TheSicker.Combat
{
    public class WeaponPickupEquipWeapon : MonoBehaviour
    {
        // config
        [SerializeField] Weapon weapon = null;
        
        public void EquipWeapon(GameObject equipWeaponTo)
        {
            IWeaponPIcker _weaponPicker = equipWeaponTo.GetComponent<IWeaponPIcker>();

            _weaponPicker.EquipWeapon(weapon);
        }
    }
}
