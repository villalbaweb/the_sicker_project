using TheSicker.GameDifficulty;
using UnityEngine;

namespace TheSicker.UI
{
    public class GameLevelSelectionController : MonoBehaviour
    {
        // config params
        [SerializeField] DifficultyLevel difficultyLevel;

        // cache
        GameDifficultyController _gameDifficultyController;

        private void Awake()
        {
            _gameDifficultyController = FindObjectOfType<GameDifficultyController>();
        }

        public void SetDifficultyLevelClicked()
        {
            if (!_gameDifficultyController) return;

            _gameDifficultyController.SetDifficultyLevel(difficultyLevel);
        }
    }
}
