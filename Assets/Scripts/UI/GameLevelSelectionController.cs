using TheSicker.GameDifficulty;
using UnityEngine;

namespace TheSicker.UI
{
    public class GameLevelSelectionController : MonoBehaviour
    {
        [SerializeField] DifficultyLevel difficultyLevel;

        public void SetDifficultyLevelClicked()
        {
            print($"Easy Level Selected {difficultyLevel}...");
        }
    }
}
