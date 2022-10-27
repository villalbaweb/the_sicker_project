using TheSicker.Game;
using UnityEngine;

namespace TheSicker.UI
{
    public class DifficultySelectionSceneStartButtonHandler : MonoBehaviour
    {
        // cache
        GameSceneController _gameSceneController;

        private void Awake()
        {
            _gameSceneController = FindObjectOfType<GameSceneController>();
        }

        public void StartButtonPressed()
        {
            _gameSceneController.LoadPlayLevel();
        }
    }
}
