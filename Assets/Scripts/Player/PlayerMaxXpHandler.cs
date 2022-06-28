using System;
using TheSicker.GameDifficulty;
using TheSicker.SaveSystem;
using TheSicker.Stats;
using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerMaxXpHandler : MonoBehaviour, ISaveableComponent
    {

        // cache
        SaveSystemWrapper _saveSystemWrapper;
        GameDifficultyController _gameDifficultyController;
        Experience _experience;

        // state
        bool isMaxXpLevelReached = false;
        float maxExperiencePoints;
        StateType selectedStateType;

        // events
        public Action OnMaxXpUpdated;

        // props
        public float MaxExperiencePoints => maxExperiencePoints;

        private void Awake()
        {
            _saveSystemWrapper = FindObjectOfType<SaveSystemWrapper>();
            _gameDifficultyController = FindObjectOfType<GameDifficultyController>();
            _experience = GetComponent<Experience>();
        }

        private void Start()
        {
            SetStateTypeBasedOnDifficulty();
            _saveSystemWrapper?.GetMaxXpPoint(selectedStateType);
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

            _saveSystemWrapper.SaveMaxXpPoint(selectedStateType);
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

        private void SetStateTypeBasedOnDifficulty()
        {
            DifficultyLevel difficultyLevel = _gameDifficultyController 
                ? _gameDifficultyController.GetSelectedDifficultyLevel() 
                : DifficultyLevel.Easy;

            switch (difficultyLevel)
            {
                case DifficultyLevel.Easy:
                    selectedStateType = StateType.MaxXpEasy;
                    break;

                case DifficultyLevel.Medium:
                    selectedStateType = StateType.MaxXpMedium;
                    break;

                case DifficultyLevel.Hard:
                    selectedStateType = StateType.MaxXpHard;
                    break;
            }
        }

        #region ISaveableComponent Implementation

        public object CaptureState(StateType stateType)
        {
            if (stateType != StateType.MaxXpEasy && stateType != StateType.MaxXpMedium && stateType != StateType.MaxXpHard) return null;

            return maxExperiencePoints;
        }

        public void RestoreState(StateType stateType, object state)
        {
            if (stateType != StateType.MaxXpEasy && stateType != StateType.MaxXpMedium && stateType != StateType.MaxXpHard) return;

            maxExperiencePoints = (float)state;
        }

        #endregion
    }
}
