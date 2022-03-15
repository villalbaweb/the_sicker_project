using UnityEngine;
using UnityEngine.EventSystems;

namespace TheSicker.Menu
{
    public class MusicButtonController : MonoBehaviour, IPointerDownHandler
    {
        #region IPointerDownHandler Implementation 

        public void OnPointerDown(PointerEventData eventData)
        {
            print("Music Button click...");
        }

        #endregion
    }
}
