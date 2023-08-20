using TheSicker.Core;
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
        TutorialEnablingControlsTextController _tutorialEnablingControlsTextController;
        ObjectPoolSpawner _objectPoolSpawner;

        private void Awake()
        {
            _playerTutorialControlHandler = FindObjectOfType<PlayerTutorialControlHandler>();
            _playerMover = FindObjectOfType<PlayerMover>();
            _tutorialEnablingControlsTextController = FindObjectOfType<TutorialEnablingControlsTextController>();
            _objectPoolSpawner = FindObjectOfType<ObjectPoolSpawner>();
            _playerRotation = _playerMover.gameObject.GetComponent<PlayerRotation>();
        }

        public void PlayerControlsDisable()
        {
            if (!_playerTutorialControlHandler) return;

            _playerRotation?.TutorialModeSet(true);
            _playerTutorialControlHandler.PlayerControls(false);
            _objectPoolSpawner.gameObject.SetActive(false);
        }

        public void ControlsEnabledTextDisplay()
        {
            if (!_tutorialEnablingControlsTextController) return;

            _tutorialEnablingControlsTextController.EnableControlsTextDisplay();
        }

        public void PlayerControlsEnable()
        {
            if (!_playerTutorialControlHandler) return;

            _playerRotation?.TutorialModeSet(false);
            _playerTutorialControlHandler.PlayerControls(true);
            _objectPoolSpawner.gameObject.SetActive(true);
        }

        public void TurnUp()
        {
            _playerRotation?.TutorialSetDirection(Vector3.up);
        }

        public void TurnDown()
        {
            _playerRotation?.TutorialSetDirection(Vector3.down);
        }

        public void TurnLeft()
        {
            _playerRotation?.TutorialSetDirection(Vector3.left);
        }

        public void TurnRight()
        {
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
