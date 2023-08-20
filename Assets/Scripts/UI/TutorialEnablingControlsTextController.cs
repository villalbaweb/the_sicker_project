using UnityEngine;
using TMPro;

namespace TheSicker.UI
{
    public class TutorialEnablingControlsTextController : MonoBehaviour
    {
        // cache
        TextMeshProUGUI _enableControlsText;

        void Awake()
        {
            _enableControlsText = GetComponent<TextMeshProUGUI>();
            _enableControlsText.enabled = false;
        }

        public void EnableControlsTextDisplay(bool enable)
        {
            _enableControlsText.enabled = enable;
        }
    }
}
