using UnityEngine;

namespace TheSicker.Game
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
