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

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isPaused = !isPaused;

            SetTimeScale(isPaused);
            SetImage(isPaused);
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
    }
}
