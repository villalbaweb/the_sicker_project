using UnityEngine;

namespace TheSicker.Combat
{
    public class WeaponPickup : MonoBehaviour
    {
        // config
        [SerializeField] Weapon weapon = null;

        private void OnTriggerEnter2D(Collider2D other) 
        {
            print("Pickup collision...");    
        }
    }
}
