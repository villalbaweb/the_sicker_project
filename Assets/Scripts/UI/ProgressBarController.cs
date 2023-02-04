using TheSicker.Core;
using TheSicker.Player;
using UnityEngine;

namespace TheSicker.UI
{
    public class ProgressBarController : MonoBehaviour
    {
        // config
        [SerializeField] float _value = 0.0f;
        [SerializeField] ProgressBar _progressBar;

        // cache
        PlayerMarker _player;
        Health _health;

        void Awake()
        {
            _player = FindObjectOfType<PlayerMarker>();
            _health = _player?.GetComponent<Health>();
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
            _progressBar.BarValue = _health.CurrentHealth;
        }
    }
}
