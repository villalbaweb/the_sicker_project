using TheSicker.Game;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TheSicker.Menu
{
    public class MusicButtonController : MonoBehaviour, IPointerDownHandler
    {
        // config params
        [SerializeField] GameMusic gameMusic = null;

        // state
        Image _musicButtonImage;

        private void Awake()
        {
            _musicButtonImage = GetComponent<Image>();
        }

        #region Private Methods

        private void SwitchImageColor()
        {
            gameMusic.IsMusicMute = !gameMusic.IsMusicMute;
            _musicButtonImage.color =  gameMusic.IsMusicMute ? new Color(255, 0, 0) : new Color(255, 255 ,255); 
        }

        #endregion

        #region IPointerDownHandler Implementation 

        public void OnPointerDown(PointerEventData eventData)
        {
            SwitchImageColor();
        }

        #endregion
    }
}
