using TheSicker.Player;
using UnityEngine;

namespace TheSicker.UI
{
    public class TutorialAnimationController : MonoBehaviour
    {
        // cache
        PlayerTutorialControlHandler _playerTutorialControlHandler;
        PlayerMover _playerMover;
        PlayerRotation _playerRotation;

        private void Awake()
        {
            _playerTutorialControlHandler = FindObjectOfType<PlayerTutorialControlHandler>();
            _playerMover = FindObjectOfType<PlayerMover>();
            _playerRotation = _playerMover.gameObject.GetComponent<PlayerRotation>();
        }

        public void PlayerControlsDisable()
        {
            if (!_playerTutorialControlHandler) return;

            _playerRotation?.TutorialModeSet(true);
            _playerTutorialControlHandler.PlayerControls(false);
        }

        public void PlayerControlsEnable()
        {
            if (!_playerTutorialControlHandler) return;

            _playerRotation?.TutorialModeSet(false);
            _playerTutorialControlHandler.PlayerControls(true);
        }

        public void TurnUp()
        {
            print("Up..");
            _playerRotation?.TutorialSetDirection(Vector3.up);
        }

        public void TurnDown()
        {
            print("Down..");
            _playerRotation?.TutorialSetDirection(Vector3.down);
        }

        public void TurnLeft()
        {
            print("Left..");
            _playerRotation?.TutorialSetDirection(Vector3.left);
        }

        public void TurnRight()
        {
            print("Right..");
            _playerRotation?.TutorialSetDirection(Vector3.right);
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
