using TheSicker.Game;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TheSicker.Menu
{
    public class SoundButtonController : MonoBehaviour, IPointerDownHandler
    {
        // config params
        [SerializeField] GameSound gameSound = null;

        // state
        Image _soundButtonImage;

        private void Awake()
        {
            _soundButtonImage = GetComponent<Image>();

            SwitchImageColor();
        }

        #region Private Methods

        private void SwitchImageColor()
        {
            if (!gameSound) return;

            _soundButtonImage.color = gameSound.IsSoundMute ? new Color(255, 0, 0) : new Color(255, 255, 255);
        }

        private void SwitchIsSoundMuteState()
        {
            if (!gameSound) return;

            gameSound.IsSoundMute = !gameSound.IsSoundMute;
        }

        #endregion

        #region IPointerDownHandler Implementation 

        public void OnPointerDown(PointerEventData eventData)
        {
            SwitchIsSoundMuteState();
            SwitchImageColor();
        }

        #endregion
    }
}
