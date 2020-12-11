using UnityEngine;

namespace TheSicker.Combat
{
    public class WeaponPickup : MonoBehaviour
    {
        // config
        [SerializeField] Weapon weapon = null;

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.tag != "Player") return;

            IWeaponPIcker _weaponPicker = other.GetComponent<IWeaponPIcker>();

            _weaponPicker.EquipWeapon(weapon);
        }
    }
}
