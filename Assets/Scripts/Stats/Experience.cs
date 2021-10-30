using System;
using TheSicker.SaveSystem;
using UnityEngine;

namespace TheSicker.Stats
{
    public class Experience : MonoBehaviour, ISaveableComponent
    {
        // config
        [SerializeField] float experiencePoints = 0;

        // properties
        public float ExperiencePoints => experiencePoints;

        // events
        public event Action OnExperienceGainedEvent;

        private void Awake()
        {
            OnExperienceGainedEvent?.Invoke();
        }

        public void GainExperience(float experience)
        {
            experiencePoints += experience;

            OnExperienceGainedEvent?.Invoke();
        }

        public float GetExperience()
        {
            return experiencePoints;
        }


        #region ISaveableComponent Implementation

        public object CaptureState(StateType stateType)
        {
            if (stateType != StateType.General) return null;

            return experiencePoints;
        }

        public void RestoreState(StateType stateType, object state)
        {
            if (stateType != StateType.General) return;

            experiencePoints = (float)state;
            OnExperienceGainedEvent?.Invoke();
        }

        #endregion
    }
}
