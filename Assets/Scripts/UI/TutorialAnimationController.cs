using TheSicker.Player;
using UnityEngine;

namespace TheSicker.UI
{
    public class TutorialAnimationController : MonoBehaviour
    {
        // cache
        PlayerTutorialControlHandler _playerTutorialControlHandler;
        PlayerMover _playerMover;

        private void Awake()
        {
            _playerTutorialControlHandler = FindObjectOfType<PlayerTutorialControlHandler>();
            _playerMover = FindObjectOfType<PlayerMover>();
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

        public void TurnUp()
        {
            print("Up..");
        }

        public void TurnDown()
        {
            print("Down..");
        }

        public void TurnLeft()
        {
            print("Left..");
        }

        public void TurnRight()
        {
            print("Right..");
        }

        public void ThrotleOn()
        {
            _playerMover?.MoveBtnDown();
        }

        public void ThrotleOff()
        {
            _playerMover?.MoveBtnUp();
        }
    }
}
