using TheSicker.Game;
using UnityEngine;

namespace TheSicker.UI
{
    public class DifficultySelectionSceneStartButtonHandler : MonoBehaviour
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
            _gameSceneController.LoadPlayLevel();
            _gameSoundController.PlayClipAtCamera(_clip);
        }
    }
}
