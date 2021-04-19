using UnityEngine;
using TheSicker.Player;
using TheSicker.Core;
using TMPro;

namespace TheSicker.Controls
{
    public class HealthTextController : MonoBehaviour
    {
        // cache
        PlayerMarker _player;
        Health _health;
        TextMeshProUGUI _healthText;

        void Awake() 
        {
            _player = FindObjectOfType<PlayerMarker>();    
            _health = _player?.GetComponent<Health>();
            _healthText = GetComponent<TextMeshProUGUI>();
        }

        void OnEnable() 
        {
            if (!_health) return;

            _health.OnHealthChange += OnHealthChange;    
        }

        void OnDisable() 
        {
            if (!_health) return;

            _health.OnHealthChange -= OnHealthChange;    
        }

        void OnHealthChange()
        {
            if(!_healthText) return;

            _healthText.text = $"Healt: {_health.CurrentHealth}";
        }
    }
}
