using UnityEngine;

namespace TheSicker.Core
{
    public class ObjectPickUpPickedHandler : MonoBehaviour
    {
        public void PickUp()
        {
            gameObject.SetActive(false);
        }
    }
}