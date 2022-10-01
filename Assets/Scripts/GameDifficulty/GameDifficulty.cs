using UnityEngine;

namespace TheSicker.GameDifficulty
{
    [CreateAssetMenu(fileName = "GameDifficulty", menuName = "Game Configuration/New GameDifficulty", order = 1)]
    public class GameDifficulty : ScriptableObject
    {
        // config props
        [SerializeField] DifficultyLevel gameDifficultySelected;
        [SerializeField] float easyEnemyDamageFactor = 1.0f;
        [SerializeField] float mediumEnemyDamageFactor = 1.25f;
        [SerializeField] float hardEnemyDamageFactor = 1.5f;

        // properties
        public DifficultyLevel GameDifficultySelected => gameDifficultySelected;
        public DifficultyLevel SetDifficultyLevel { set { gameDifficultySelected = value; } }
        public float EasyEnemyDamageFactor => easyEnemyDamageFactor;
        public float MediumEnemyDamageFactor => mediumEnemyDamageFactor;
        public float HardEnemyDamageFactor => hardEnemyDamageFactor;
    }
}
