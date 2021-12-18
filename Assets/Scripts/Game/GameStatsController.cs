using TheSicker.Player;
using TheSicker.Stats;
using UnityEngine;

namespace TheSicker.Game
{
    public class GameStatsController : MonoBehaviour
    {
        // cache
        PlayerMarker _player;
        PlayerMaxXpHandler _playerMaxXpHandler;
        Experience _experience;

        // private members
        [SerializeField] private float playerMaxXp;
        [SerializeField] private float playerXp;

        // properties
        public float PlayerMaxXp => playerMaxXp;
        public float PlayerXp => playerXp;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerMarker>();
            _playerMaxXpHandler = _player?.GetComponent<PlayerMaxXpHandler>();
            _experience = _player?.GetComponent<Experience>();
        }

        void OnEnable()
        {
            SubscribeEvents();
        }

        void OnDisable()
        {
            UnSubscribeEvents();
        }

        void OnMaxXpUpdated()
        {
            playerMaxXp = _playerMaxXpHandler.MaxExperiencePoints;
        }

        private void OnExperienceGained()
        {
            playerXp = _experience.ExperiencePoints;
        }

        private void SubscribeEvents()
        {
            if (_playerMaxXpHandler)
            {
                _playerMaxXpHandler.OnMaxXpUpdated += OnMaxXpUpdated;
            }

            if (_experience)
            {
                _experience.OnExperienceGainedEvent += OnExperienceGained;
            }
        }

        private void UnSubscribeEvents()
        {
            if (_playerMaxXpHandler)
            {
                _playerMaxXpHandler.OnMaxXpUpdated -= OnMaxXpUpdated;
            }

            if (_experience)
            {
                _experience.OnExperienceGainedEvent -= OnExperienceGained;
            }
        }
    }
}
