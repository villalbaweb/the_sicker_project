using System.Collections;
using TheSicker.Game;
using UnityEngine;

namespace TheSicker.UI
{
    public class SplashSceneExitButtonHandler : MonoBehaviour
    {
        // cache
        GameSoundController _gameSoundController;

        private void Awake()
        {
            _gameSoundController = FindObjectOfType<GameSoundController>();
        }

        public void ExitButtonPressed()
        {
            StartCoroutine(ExitWithSound());
        }

        private IEnumerator ExitWithSound()
        {
            yield return new WaitForSeconds(2.0f);

            Application.Quit();
        }
    }
}
