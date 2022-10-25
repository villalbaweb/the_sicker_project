using TheSicker.Game;
using UnityEngine;

namespace TheSicker.UI
{
    public class SplashSceneStartButtonHandler : MonoBehaviour
    {
        // config
        [SerializeField] AudioClip _clip;
        // cache
        GameSceneController _gameSceneController;
        GameSoundController _gameSoundController;

        private void Awake()
        {
            _gameSceneController = FindObjectOfType<GameSceneController>();
            _gameSoundController = FindObjectOfType<GameSoundController>();
        }

        public void StartButtonPressed()
        {
            _gameSceneController.LoadDifficultySelectionMenu();
            _gameSoundController.PlayClipAtCamera(_clip);
        }
    }
}
