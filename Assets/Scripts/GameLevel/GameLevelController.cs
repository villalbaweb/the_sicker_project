using System;
using TheSicker.Player;
using UnityEngine;

namespace TheSicker.GameLevel
{
    public class GameLevelController : MonoBehaviour
    {
        // cache
        PlayerMarker _playerMarker;
        PlayerXpLevelHandler _playerXpLevelHandler;

        // events
        public event Action OnGameLevelUpEvent;

        // state
        int gameCurrentLevel;

        // properties
        public int GameCurrentLevel => gameCurrentLevel;

        private void Awake()
        {
            _playerMarker = FindObjectOfType<PlayerMarker>();
            _playerXpLevelHandler = _playerMarker?.GetComponent<PlayerXpLevelHandler>();
            UpdateGameLevel();
        }

        private void Start()
        {
            UpdateGameLevel();
        }

        private void OnEnable()
        {
            _playerXpLevelHandler.OnPlayerLevelUpEvent += OnPlayerLevelUp;
        }

        private void OnDisable()
        {
            _playerXpLevelHandler.OnPlayerLevelUpEvent -= OnPlayerLevelUp;
        }

        private void OnPlayerLevelUp()
        {
            UpdateGameLevel();
        }

        /// <summary>
        /// Update several stats from Progression asset, this will be invoked OnAwake, OnStart and everytime there is a OnPLayerLevelUpEvent
        /// </summary>
        private void UpdateGameLevel()
        {
            if (!_playerXpLevelHandler) return;

            gameCurrentLevel = _playerXpLevelHandler.CurrentLevel;

            OnGameLevelUpEvent?.Invoke();
        }
    }
}
