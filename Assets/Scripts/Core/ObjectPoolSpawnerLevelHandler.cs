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
        int gameLevelBasedTimeToSpawn;

        // properties
        public int GameLevelBasedTimeToSpawn => gameLevelBasedTimeToSpawn;

        private void Awake()
        {
            _gameLevelController = FindObjectOfType<GameLevelController>();
            _baseStats = GetComponent<BaseStats>();
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

            gameLevelBasedTimeToSpawn = (int)_baseStats.GetStat(Stat.Wildcard);

            print($"[{gameObject.name}] Game level up to {_gameLevelController.GameCurrentLevel} spwan time {gameLevelBasedTimeToSpawn}");
        }
    }
}
