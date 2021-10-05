using TheSicker.Player;
using TheSicker.Stats;
using UnityEngine;

namespace TheSicker.Enemies
{
    public class ExperiencePointsProviderHandler : MonoBehaviour
    {
        // cache
        BaseStats _baseStats;
        PlayerMarker _playerMarker;

        private void Awake()
        {
            _baseStats = GetComponent<BaseStats>();
            _playerMarker = FindObjectOfType<PlayerMarker>();
        }

        public void ExperienceAward()
        {
            if (!_baseStats || !_playerMarker) return;

            Experience playerExperience = _playerMarker.GetComponent<Experience>();
            playerExperience.GainExperience(_baseStats.GetStat(Stat.ExperienceReward));
        }
    }
}
