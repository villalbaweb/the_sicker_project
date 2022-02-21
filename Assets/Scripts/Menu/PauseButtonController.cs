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
        GameMenuPanelController _gameMenuPanelController;

        private void Awake()
        {
            _image = GetComponent<Image>();

            _gameMenuPanelController = FindObjectOfType<GameMenuPanelController>();
            _gameMenuPanelController?.gameObject.SetActive(false);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isPaused = !isPaused;

            SetTimeScale(isPaused);
            SetImage(isPaused);
            SetPanel(isPaused);
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
            if(!_gameMenuPanelController) return;

            _gameMenuPanelController.gameObject.SetActive(!isPaused);
        }
    }
}
