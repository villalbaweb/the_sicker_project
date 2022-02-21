using UnityEngine;
using UnityEngine.EventSystems;

namespace TheSicker.Menu
{
    public class CloseButtonController : MonoBehaviour, IPointerDownHandler
    {
        // cache
        PauseButtonController _pauseButtonController;

        #region Private Methods

        private void Awake()
        {
            _pauseButtonController = FindObjectOfType<PauseButtonController>();
        }

        #endregion


        #region IPointerDownHandler Implementation 

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_pauseButtonController) return;

            _pauseButtonController.PauseButtonClick();
        }

        #endregion
    }
}
