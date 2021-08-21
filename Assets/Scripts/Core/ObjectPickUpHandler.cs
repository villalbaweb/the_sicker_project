using UnityEngine;
using UnityEngine.Events;

namespace TheSicker.Core
{
    public class ObjectPickUpHandler : MonoBehaviour
    {
        // config
        [SerializeField] ObjectPickupEvent onPickUpEvent = null;

        [System.Serializable]
        public class ObjectPickupEvent : UnityEvent<GameObject> { }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.tag != "Player") return;

            onPickUpEvent.Invoke(other.gameObject);
        }
    }
}
