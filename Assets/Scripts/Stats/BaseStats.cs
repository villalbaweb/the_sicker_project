using TheSicker.GameLevel;
using UnityEngine;

namespace TheSicker.Stats
{
    public class BaseStats : MonoBehaviour, IBaseStatsGetter
    {
        // config
        [Range(1, 5)]
        [SerializeField] int startingLevel = 1;
        [SerializeField] CharacterClass characterClass;
        [SerializeField] Progression progression = null;

        // properties
        public int StartingLevel => startingLevel;
        public Progression Progression => progression;
        public CharacterClass CharacterClass => characterClass;

        // cache
        GameLevelController _gameLevelController;

        private void Awake()
        {
            _gameLevelController = FindObjectOfType<GameLevelController>();
        }

        #region Public Methods

        public float GetStat(Stat statToGet)
        {
            return progression ? GetBaseStat(statToGet) : 0;
        }

        #endregion

        #region Private Methods

        private float GetBaseStat(Stat statToGet)
        {
            return progression.GetStat(statToGet, characterClass, _gameLevelController.GameCurrentLevel);
        }

        #endregion
    }
}
