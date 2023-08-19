using TheSicker.Controls;
using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerTutorialControlHandler : MonoBehaviour
    {
        // config
        [SerializeField] bool IsTutorialPlayer = false;

        // cache
        PlayerRotation _playerRotation;
        SpeedButtonControler _speedButtonControler;

        private void Awake()
        {
            _playerRotation = GetComponent<PlayerRotation>();
            _speedButtonControler = FindObjectOfType<SpeedButtonControler>();
        }

        public void PlayerControls(bool enable)
        {
            if (!IsTutorialPlayer || !_speedButtonControler || !_playerRotation) return;

            _speedButtonControler.gameObject.SetActive(enable);
            _playerRotation.enabled = enable;   // change this to enable disable the joystick perhaps ???
        }

    }
}
