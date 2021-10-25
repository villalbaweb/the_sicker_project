using TheSicker.GameLevel;
using TheSicker.Stats;
using UnityEngine;

namespace TheSicker.Core
{
    public class ObjectPoolSpawnerLevelHandler : MonoBehaviour
    {
        // cache
        GameLevelController _gameLevelController;
        BaseStats _baseStats;

        // state
        float gameLevelBasedTimeToSpawn;

        // properties
        public float GameLevelBasedTimeToSpawn => gameLevelBasedTimeToSpawn;

        private void Awake()
        {
            _gameLevelController = FindObjectOfType<GameLevelController>();
            _baseStats = GetComponent<BaseStats>();
            gameLevelBasedTimeToSpawn = _baseStats ? _baseStats.GetStat(Stat.Wildcard) : 5f;
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
        }
    }
}
