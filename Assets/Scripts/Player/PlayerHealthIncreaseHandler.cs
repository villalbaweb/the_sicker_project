using UnityEngine;
using TheSicker.Core;
using TheSicker.Stats;

namespace TheSicker.Player
{
    public class PlayerHealthIncreaseHandler : MonoBehaviour
    {
        // config
        [SerializeField] int increaseHealthPoints = 50;

        // cache
        IBaseStatsGetter _baseStatsGetter;

        private void Awake()
        {
            _baseStatsGetter = GetComponent<IBaseStatsGetter>();
        }

        public void IncreaseHealth(GameObject increaseHealthTo)
        {
            Health _playerHealth = increaseHealthTo.GetComponent<Health>();

            int healthPointsToIncrease = _baseStatsGetter != null
                ? (int)_baseStatsGetter.GetStat(Stat.ExperienceReward)
                : increaseHealthPoints;

            _playerHealth.IncreaseHealth(healthPointsToIncrease);
        }
    }
}
