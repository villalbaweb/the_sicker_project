using System;
using UnityEngine;

namespace TheSicker.Stats
{
    public class Experience : MonoBehaviour
    {
        // config
        [SerializeField] float experiencePoints = 0;

        // events
        public event Action OnExperienceGainedEvent;

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
