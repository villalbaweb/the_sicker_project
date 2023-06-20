using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerTutorialControlHandler : MonoBehaviour
    {
        // config
        [SerializeField] bool IsTutorialPlayer = false;

        // cache
        PlayerMover _playerMover;
        PlayerRotation _playerRotation;

        private void Awake()
        {
            _playerMover = GetComponent<PlayerMover>();
            _playerRotation = GetComponent<PlayerRotation>();
        }

        public void PlayerControls(bool enable)
        {
            if (!IsTutorialPlayer || !_playerMover || !_playerRotation) return;

            _playerMover.enabled = enable;
            _playerRotation.enabled = enable;
        }

    }
}
