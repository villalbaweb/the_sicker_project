using TheSicker.Game;
using UnityEngine;

namespace TheSicker.UI
{
    public class DifficultySelectionSceneBackButtonHandler : MonoBehaviour
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

        public void BackButtonPressed()
        {
            _gameSceneController.LoadMainMenu();
            _gameSoundController.PlayClipAtCamera(_clip);
        }
    }
}
