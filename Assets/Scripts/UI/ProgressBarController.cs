using TheSicker.Core;
using TheSicker.Player;
using UnityEngine;

namespace TheSicker.UI
{
    public class ProgressBarController : MonoBehaviour
    {
        // config
        [SerializeField] ProgressBar _progressBar;

        // cache
        PlayerMarker _player;
        Health _health;
        Animator _lifeBarAnimator;

        void Awake()
        {
            _player = FindObjectOfType<PlayerMarker>();
            _health = _player?.GetComponent<Health>();
            _lifeBarAnimator = GetComponent<Animator>();
        }

        void OnEnable()
        {
            if (!_health) return;

            _health.OnHealthChange += OnHealthChange;
            _health.OnHealthChange += HealthBelowAlertCheck;
        }

        void OnDisable()
        {
            if (!_health) return;

            _health.OnHealthChange -= OnHealthChange;
            _health.OnHealthChange -= HealthBelowAlertCheck;
        }

        void OnHealthChange()
        {
            _progressBar.BarValue = _health.CurrentHealth;
        }

        void HealthBelowAlertCheck()
        {
            if (!_lifeBarAnimator) return;
            bool isHealthAlert = _progressBar.Alert >= _health.CurrentHealth;
            _lifeBarAnimator.SetBool("IsHealthAlert", isHealthAlert);
        }
    }
}
