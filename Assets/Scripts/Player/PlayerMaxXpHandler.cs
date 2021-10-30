using TheSicker.SaveSystem;
using TheSicker.Stats;
using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerMaxXpHandler : MonoBehaviour, ISaveableComponent
    {
        // config
        [SerializeField] float maxXpLevel = 10;

        // cache
        SaveSystemWrapper _saveSystemWrapper;
        Experience _experience;

        // state
        bool isMaxXpLevelReached = false;

        private void Awake()
        {
            _saveSystemWrapper = FindObjectOfType<SaveSystemWrapper>();
            _experience = GetComponent<Experience>();
        }

        private void Start()
        {
            _saveSystemWrapper?.GetMaxXpPoint();
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

        public void MaxXpOnPlayerDieSave()
        {
            if (!isMaxXpLevelReached) return;

            _saveSystemWrapper.SaveMaxXpPoint();
        }


        private void OnExperienceGained()
        {
            float currentXP = _experience.GetExperience();
            isMaxXpLevelReached = currentXP >= maxXpLevel;

            if (isMaxXpLevelReached)
            {
                maxXpLevel = currentXP;
            }
        }

        #region ISaveableComponent Implementation

        public object CaptureState(StateType stateType)
        {
            if (stateType != StateType.MaxXp) return null;

            return maxXpLevel;
        }

        public void RestoreState(StateType stateType, object state)
        {
            if (stateType != StateType.MaxXp) return;

            maxXpLevel = (float)state;
        }

        #endregion
    }
}
