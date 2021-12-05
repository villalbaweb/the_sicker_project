using TheSicker.Game;
using UnityEngine;

namespace TheSicker.UI
{
    public class GameOverScenePlayAgainButtonHandler : MonoBehaviour
    {
        // cache
        GameSceneController _gameSceneController;

        private void Awake()
        {
            _gameSceneController = FindObjectOfType<GameSceneController>();
        }

        public void PlayAgainButtonPressed()
        {
            _gameSceneController.LoadPlayLevel();
        }
    }
}
