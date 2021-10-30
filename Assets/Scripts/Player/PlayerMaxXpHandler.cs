using System;
using TheSicker.SaveSystem;
using TheSicker.Stats;
using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerMaxXpHandler : MonoBehaviour, ISaveableComponent
    {

        // cache
        SaveSystemWrapper _saveSystemWrapper;
        Experience _experience;

        // state
        bool isMaxXpLevelReached = false;
        float maxExperiencePoints;

        // events
        public Action OnMaxXpUpdated;

        // props
        public float MaxExperiencePoints => maxExperiencePoints;

        private void Awake()
        {
            _saveSystemWrapper = FindObjectOfType<SaveSystemWrapper>();
            _experience = GetComponent<Experience>();
        }

        private void Start()
        {
            _saveSystemWrapper?.GetMaxXpPoint();
            OnMaxXpUpdated?.Invoke();
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
            isMaxXpLevelReached = currentXP >= maxExperiencePoints;

            if (isMaxXpLevelReached)
            {
                maxExperiencePoints = currentXP;
                OnMaxXpUpdated?.Invoke();
            }
        }

        #region ISaveableComponent Implementation

        public object CaptureState(StateType stateType)
        {
            if (stateType != StateType.MaxXp) return null;

            return maxExperiencePoints;
        }

        public void RestoreState(StateType stateType, object state)
        {
            if (stateType != StateType.MaxXp) return;

            maxExperiencePoints = (float)state;
        }

        #endregion
    }
}
