using TheSicker.Player;
using UnityEngine;

namespace TheSicker.UI
{
    public class TutorialAnimationController : MonoBehaviour
    {
        // cache
        PlayerTutorialControlHandler _playerTutorialControlHandler;

        private void Awake()
        {
            _playerTutorialControlHandler = FindObjectOfType<PlayerTutorialControlHandler>();
        }

        public void PlayerControlsDisable()
        {
            if (!_playerTutorialControlHandler) return;

            _playerTutorialControlHandler.PlayerControls(false);
        }

        public void PlayerControlsEnable()
        {
            if (!_playerTutorialControlHandler) return;

            _playerTutorialControlHandler.PlayerControls(true);
        }
    }
}
