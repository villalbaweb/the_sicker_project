using UnityEngine;

namespace TheSicker.GameDifficulty
{
    public class GameDifficultyController : MonoBehaviour
    {
        // config params
        [SerializeField] GameDifficulty gameDifficulty = null;

        // public methods
        public DifficultyLevel GetSelectedDifficultyLevel()
        {
            return gameDifficulty
                ? gameDifficulty.GameDifficultySelected
                : DifficultyLevel.Easy;
        }
    }
}
