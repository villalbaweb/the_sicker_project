using TheSicker.Controls;
using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerTutorialControlHandler : MonoBehaviour
    {
        // config
        [SerializeField] bool IsTutorialPlayer = false;

        // cache
        SpeedButtonControler _speedButtonControler;
        Joystick _joystick;

        private void Awake()
        {
            _speedButtonControler = FindObjectOfType<SpeedButtonControler>();
            _joystick = FindObjectOfType<Joystick>();
        }

        public void PlayerControls(bool enable)
        {
            if (!IsTutorialPlayer || !_speedButtonControler || !_joystick) return;

            _speedButtonControler.gameObject.SetActive(enable);
            _joystick.gameObject.SetActive(enable);
        }

    }
}
