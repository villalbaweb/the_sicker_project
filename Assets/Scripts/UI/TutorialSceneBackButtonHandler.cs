using TheSicker.Game;
using UnityEngine;

namespace TheSicker.UI
{
    public class TutorialSceneBackButtonHandler : MonoBehaviour
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
