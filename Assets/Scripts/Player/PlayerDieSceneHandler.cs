using TheSicker.Game;
using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerDieSceneHandler : MonoBehaviour
    {
        // cache
        GameSceneController _gameSceneController;

        private void Awake()
        {
            _gameSceneController = FindObjectOfType<GameSceneController>();
        }

        public void GameOverScreenShow()
        {
            _gameSceneController.LoadGameOver();
        }
    }
}