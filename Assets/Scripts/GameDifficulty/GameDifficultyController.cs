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

        public float GetLevelBasedEnemyDamageFactor()
        {
            float damageFactor = 1.0f;

            if (gameDifficulty)
            {
                switch (gameDifficulty.GameDifficultySelected)
                {
                    case DifficultyLevel.Easy: 
                        damageFactor = gameDifficulty.EasyEnemyDamageFactor;
                        break;

                    case DifficultyLevel.Medium:
                        damageFactor = gameDifficulty.MediumEnemyDamageFactor;
                        break;

                    case DifficultyLevel.Hard:
                        damageFactor = gameDifficulty.HardEnemyDamageFactor;
                        break;
                }
            }

            return damageFactor;
        }

        public void SetDifficultyLevel(DifficultyLevel difficultyLevel)
        {
            gameDifficulty.SetDifficultyLevel = difficultyLevel;
        }
    }
}
