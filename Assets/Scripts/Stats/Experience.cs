using System;
using UnityEngine;

namespace TheSicker.Stats
{
    public class Experience : MonoBehaviour
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
    }
}
