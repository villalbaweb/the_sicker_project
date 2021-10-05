using TheSicker.Player;
using TheSicker.Stats;
using TMPro;
using UnityEngine;

namespace TheSicker.Controls
{
    public class XpTextController : MonoBehaviour
    {
        // cache
        PlayerMarker _player;
        Experience _experience;
        TextMeshProUGUI _xpText;

        void Awake()
        {
            _player = FindObjectOfType<PlayerMarker>();
            _experience = _player?.GetComponent<Experience>();
            _xpText = GetComponent<TextMeshProUGUI>();
        }

        void OnEnable()
        {
            if (!_experience) return;

            _experience.OnExperienceGainedEvent += OnExperienceGained;
        }

        void OnDisable()
        {
            if (!_experience) return;

            _experience.OnExperienceGainedEvent -= OnExperienceGained;
        }

        void OnExperienceGained()
        {
            if (!_xpText) return;

            _xpText.text = $"XP: { _experience.ExperiencePoints }";
        }
    }
}
