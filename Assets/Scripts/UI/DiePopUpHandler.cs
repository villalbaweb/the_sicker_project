using TheSicker.Stats;
using UnityEngine;

namespace TheSicker.UI
{
    public class DiePopUpHandler : MonoBehaviour
    {
        // cache
        IBaseStatsGetter _baseStatsGetter;
        PopUpSpawner _popUpSpawner;

        private void Awake()
        {
            _baseStatsGetter = GetComponent<IBaseStatsGetter>();
            _popUpSpawner = GetComponent<PopUpSpawner>();
        }

        public void DiePopUpDisplay()
        {
            if (_baseStatsGetter == null || _popUpSpawner == null) return;

            _popUpSpawner.PopUpSpawn(_baseStatsGetter.GetStat(Stat.ExperienceReward).ToString());
        }
    }
}
