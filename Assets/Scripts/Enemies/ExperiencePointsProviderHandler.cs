using TheSicker.Player;
using TheSicker.Stats;
using UnityEngine;

namespace TheSicker.Enemies
{
    public class ExperiencePointsProviderHandler : MonoBehaviour
    {
        // cache
        IBaseStatsGetter _baseStatsGetter;
        PlayerMarker _playerMarker;

        private void Awake()
        {
            _baseStatsGetter = GetComponent<IBaseStatsGetter>();
            _playerMarker = FindObjectOfType<PlayerMarker>();
        }

        public void ExperienceAward()
        {
            if (_baseStatsGetter == null || !_playerMarker) return;

            Experience playerExperience = _playerMarker.GetComponent<Experience>();
            playerExperience.GainExperience(_baseStatsGetter.GetStat(Stat.ExperienceReward));
        }
    }
}
