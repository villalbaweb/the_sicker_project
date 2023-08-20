using UnityEngine;
using TMPro;
using System.Collections;

namespace TheSicker.UI
{
    public class TutorialEnablingControlsTextController : MonoBehaviour
    {
        // const
        const string ENABLING_CONTROLS_TEXT = "enabling controls in ... ";

        // cache
        TextMeshProUGUI _enableControlsText;

        void Awake()
        {
            _enableControlsText = GetComponent<TextMeshProUGUI>();
            _enableControlsText.enabled = false;
        }

        public void EnableControlsTextDisplay()
        {
            StartCoroutine(Countdown(3));
        }

        IEnumerator Countdown(int seconds)
        {
            int count = seconds;
            _enableControlsText.enabled = true;
            while (count > 0)
            {
                _enableControlsText.text = ENABLING_CONTROLS_TEXT + count.ToString();
                yield return new WaitForSeconds(1);
                count--;
            }

            // count down is finished...
            _enableControlsText.enabled = false;
        }
    }
}
