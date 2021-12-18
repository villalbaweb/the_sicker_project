using System.Collections;
using TheSicker.Player;
using UnityEngine;

namespace TheSicker.Game
{
    public class GameStatsController : MonoBehaviour
    {
        // cache
        PlayerMarker _player;
        PlayerMaxXpHandler _playerMaxXpHandler;

        // private members
        [SerializeField] private float playerMaxXp;

        // properties
        public float PlayerMaxXp => playerMaxXp;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerMarker>();
            _playerMaxXpHandler = _player?.GetComponent<PlayerMaxXpHandler>();
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
            playerMaxXp = _playerMaxXpHandler.MaxExperiencePoints;
        }
    }
}
