using TheSicker.Game;
using UnityEngine;

namespace TheSicker.UI
{
    public class DifficultySelectionSceneBackButtonHandler : MonoBehaviour
    {
        // cache
        GameSceneController _gameSceneController;

        private void Awake()
        {
            _gameSceneController = FindObjectOfType<GameSceneController>();
        }

        public void BackButtonPressed()
        {
            _gameSceneController.LoadMainMenu();
        }
    }
}
