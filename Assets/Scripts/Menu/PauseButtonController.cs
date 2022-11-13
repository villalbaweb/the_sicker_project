using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TheSicker.Menu
{
    public class PauseButtonController : MonoBehaviour, IPointerDownHandler
    {
        // config
        [SerializeField] Sprite pauseSprite = null;
        [SerializeField] Sprite resumeSprite = null;

        // state
        private bool isPaused = false;

        // cache
        Image _image;
        GameMenuController _gameMenuController;

        #region Private Methods

        private void Awake()
        {
            _image = GetComponent<Image>();

            _gameMenuController = FindObjectOfType<GameMenuController>();
        }


        private void SetTimeScale(bool isPaused)
        {
            Time.timeScale = isPaused ? 1 : 0;
        }

        private void SetImage(bool isPaused)
        {
            if (!_image) return;

            _image.sprite = isPaused ? pauseSprite : resumeSprite;
        }

        private void SetPanel(bool isPaused)
        {
            if(!_gameMenuController) return;

            _gameMenuController.SetGameMenuEnabled(!isPaused);
        }

        #endregion


        #region Public Methods

        public void PauseButtonClick()
        {
            isPaused = !isPaused;

            SetTimeScale(isPaused);
            SetImage(isPaused);
            SetPanel(isPaused);
        }

        #endregion


        #region IPointerDownHandler Implementation 

        public void OnPointerDown(PointerEventData eventData)
        {
            PauseButtonClick();
        }

        #endregion
    }
}
