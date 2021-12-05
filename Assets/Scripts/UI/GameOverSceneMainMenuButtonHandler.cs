using TheSicker.Game;
using UnityEngine;

namespace TheSicker.UI
{
    public class GameOverSceneMainMenuButtonHandler : MonoBehaviour
    {
        // cache
        GameSceneController _gameSceneController;

        private void Awake()
        {
            _gameSceneController = FindObjectOfType<GameSceneController>();
        }

        public void MainMenuButtonPressed()
        {
            _gameSceneController.LoadMainMenu();
        }
    }
}
