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

            SwitchImageColor();
        }

        #region Private Methods

        private void SwitchImageColor()
        {
            if (!gameMusic) return;

            _musicButtonImage.color =  gameMusic.IsMusicMute ? new Color(255, 0, 0) : new Color(255, 255 ,255); 
        }

        private void SwitchIsMusicMuteState()
        {
            if (!gameMusic) return;

            gameMusic.IsMusicMute = !gameMusic.IsMusicMute;
            gameMusic.OnIsMusicMuteChange?.Invoke();
        }

        #endregion

        #region IPointerDownHandler Implementation 

        public void OnPointerDown(PointerEventData eventData)
        {
            SwitchIsMusicMuteState();
            SwitchImageColor();
        }

        #endregion
    }
}
