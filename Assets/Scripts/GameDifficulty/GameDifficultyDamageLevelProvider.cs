using TheSicker.Core;
using TheSicker.Stats;
using UnityEngine;

namespace TheSicker.GameDifficulty
{
    public class GameDifficultyDamageLevelProvider : MonoBehaviour, IPooledObject
    {
        // cache
        IBaseStatsGetter _baseStatsGetter;
        GameDifficultyController _gameDifficultyController;

        // state
        float DamageFactor;

        private void Awake()
        {
            _baseStatsGetter = GetComponent<IBaseStatsGetter>();
            _gameDifficultyController = FindObjectOfType<GameDifficultyController>();
        }

        #region Public Methods

        public int GetDamageLevel()
        {
            float baseStatsDamage = _baseStatsGetter != null ? (int)_baseStatsGetter.GetStat(Stat.Damage) : 0;
            float calculatedDamage = baseStatsDamage * DamageFactor;

            return (int)calculatedDamage;
        }

        #endregion

        #region On Object Spawn

        public void OnObjectSpawn()
        {
            DamageFactor = _gameDifficultyController ? _gameDifficultyController.GetLevelBasedEnemyDamageFactor() : 1;
        }

        #endregion
    }
}
