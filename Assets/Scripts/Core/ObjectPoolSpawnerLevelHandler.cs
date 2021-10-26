using TheSicker.GameLevel;
using TheSicker.Stats;
using UnityEngine;

namespace TheSicker.Core
{
    public class ObjectPoolSpawnerLevelHandler : MonoBehaviour
    {
        // config
        [SerializeField] float defaultTimeToSpawn = 5f;

        // cache
        GameLevelController _gameLevelController;
        BaseStats _baseStats;

        // state
        float gameLevelBasedTimeToSpawn;
        int gameLevel;

        // properties
        public float GameLevelBasedTimeToSpawn => gameLevelBasedTimeToSpawn;
        public int GameLevel => gameLevel;

        private void Awake()
        {
            _gameLevelController = FindObjectOfType<GameLevelController>();
            _baseStats = GetComponent<BaseStats>();
            gameLevelBasedTimeToSpawn = defaultTimeToSpawn;
        }

        private void OnEnable()
        {
            _gameLevelController.OnGameLevelUpEvent += OnGameLevelUp;
        }

        private void OnDisable()
        {
            _gameLevelController.OnGameLevelUpEvent -= OnGameLevelUp;
        }

        private void OnGameLevelUp()
        {
            if (!_baseStats) return;

            gameLevelBasedTimeToSpawn = _baseStats.GetStat(Stat.Wildcard);
            gameLevel = _gameLevelController.GameCurrentLevel;
        }
    }
}
