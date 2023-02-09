using TheSicker.Game;
using UnityEngine;

namespace TheSicker.UI
{
    public class TutorialSceneContinueButtonHandler : MonoBehaviour
    {
        // cache
        GameSceneController _gameSceneController;

        private void Awake()
        {
            _gameSceneController = FindObjectOfType<GameSceneController>();
        }

        public void ContinueButtonPressed()
        {
            _gameSceneController.LoadDifficultySelectionMenu();
        }
    }
}
