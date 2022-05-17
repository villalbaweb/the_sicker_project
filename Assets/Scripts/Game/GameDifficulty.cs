using UnityEngine;

namespace TheSicker.Game
{
    [CreateAssetMenu(fileName = "GameDifficulty", menuName = "Game Configuration/New GameDifficulty", order = 1)]
    public class GameDifficulty : ScriptableObject
    {
        // config props
        [SerializeField] DifficultyLevel gameDifficultySelected;

        // properties
        public DifficultyLevel GameDifficultySelected => gameDifficultySelected;
    }
}
