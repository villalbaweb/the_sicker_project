using System;
using TheSicker.Stats;
using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerXpLevelHandler : MonoBehaviour
    {
        // cache
        Experience _experience;
        BaseStats _baseStats;

        // state
        int currentLevel = 1;
        public int CurrentLevel => currentLevel;

        // events
        public event Action OnPlayerLevelUpEvent;


        private void Awake()
        {
            _experience = GetComponent<Experience>();
            _baseStats = GetComponent<BaseStats>();

            currentLevel = GetExperienceLevel();
        }

        private void OnEnable()
        {
            if (_experience)
            {
                _experience.OnExperienceGainedEvent += OnExperienceGained;
            }
        }

        private void OnDisable()
        {
            if (_experience)
            {
                _experience.OnExperienceGainedEvent -= OnExperienceGained;
            }
        }

        private void OnExperienceGained()
        {
            int calculatedLevel = GetExperienceLevel();

            if (calculatedLevel > currentLevel)
            {
                currentLevel = calculatedLevel;
                OnPlayerLevelUpEvent?.Invoke();
            }
        }

        private int GetExperienceLevel()
        {
            if (!_experience) { return _baseStats.StartingLevel; }

            float currentXP = _experience.GetExperience();
            int penultimateLevel = _baseStats.Progression ? _baseStats.Progression.GetLevels(Stat.ExperienceToLevelUp, _baseStats.CharacterClass) : 0;
            for (int level = 1; level <= penultimateLevel; level++)
            {
                float XPToLevelUp = _baseStats.Progression ? _baseStats.Progression.GetStat(Stat.ExperienceToLevelUp, _baseStats.CharacterClass, level) : 0;
                if (currentXP < XPToLevelUp)
                {
                    return level;
                }
            }

            return penultimateLevel + 1;
        }
    }
}
