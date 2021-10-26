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
        IBaseStatsGetter _baseStatsGetter;

        // state
        float gameLevelBasedTimeToSpawn;
        int gameLevel;

        // properties
        public float GameLevelBasedTimeToSpawn => gameLevelBasedTimeToSpawn;
        public int GameLevel => gameLevel;

        private void Awake()
        {
            _gameLevelController = FindObjectOfType<GameLevelController>();
            _baseStatsGetter = GetComponent<IBaseStatsGetter>();
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
            if (_baseStatsGetter == null) return;

            gameLevelBasedTimeToSpawn = _baseStatsGetter.GetStat(Stat.Wildcard);
            gameLevel = _gameLevelController.GameCurrentLevel;
        }
    }
}
