using UnityEngine;
using UnityEngine.Events;

namespace TheSicker.Combat
{
    public class WeaponPickup : MonoBehaviour
    {
        // config
        [SerializeField] WeaponPickupEvent onPickUpEvent = null;

        [System.Serializable]
        public class WeaponPickupEvent : UnityEvent<GameObject> { }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.tag != "Player") return;

            onPickUpEvent.Invoke(other.gameObject);


        }
    }
}
