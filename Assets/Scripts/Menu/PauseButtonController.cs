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
            print("Pause pointer down...");
            isPaused = !isPaused;

            if (isPaused)
            {
                _image.sprite = resumeSprite;
            }
            else
            {
                _image.sprite = pauseSprite;
            }
        }
    }
}
