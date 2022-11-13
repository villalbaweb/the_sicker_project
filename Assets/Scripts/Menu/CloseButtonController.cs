using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace TheSicker.Menu
{
    public class CloseButtonController : MonoBehaviour, IPointerDownHandler
    {
        // config
        [SerializeField] UnityEvent onClick = null;

        #region IPointerDownHandler Implementation 

        public void OnPointerDown(PointerEventData eventData)
        {
            onClick?.Invoke();
        }

        #endregion
    }
}
