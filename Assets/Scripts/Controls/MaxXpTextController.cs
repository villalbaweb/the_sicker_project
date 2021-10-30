using TheSicker.Player;
using TMPro;
using UnityEngine;

namespace TheSicker.Controls
{
    public class MaxXpTextController : MonoBehaviour
    {
        // cache
        PlayerMarker _player;
        PlayerMaxXpHandler _playerMaxXpHandler;
        TextMeshProUGUI _xpText;

        void Awake()
        {
            _player = FindObjectOfType<PlayerMarker>();
            _playerMaxXpHandler = _player?.GetComponent<PlayerMaxXpHandler>();
            _xpText = GetComponent<TextMeshProUGUI>();
        }

        void OnEnable()
        {
            if (!_playerMaxXpHandler) return;

            _playerMaxXpHandler.OnMaxXpUpdated += OnMaxXpUpdated;
        }

        void OnDisable()
        {
            if (!_playerMaxXpHandler) return;

            _playerMaxXpHandler.OnMaxXpUpdated -= OnMaxXpUpdated;
        }

        void OnMaxXpUpdated()
        {
            if (!_xpText) return;

            _xpText.text = $"Max XP: { _playerMaxXpHandler.MaxExperiencePoints }";
        }
    }
}
