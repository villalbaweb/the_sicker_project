using TheSicker.Player;
using UnityEngine;

namespace TheSicker.GameLevel
{
    public class GameLevelController : MonoBehaviour
    {
        // cache
        PlayerMarker _playerMarker;
        PlayerXpLevelHandler _playerXpLevelHandler;

        // state
        int gameCurrentLevel;

        // properties
        public int GameCurrentLevel => gameCurrentLevel;

        private void Awake()
        {
            _playerMarker = FindObjectOfType<PlayerMarker>();
            _playerXpLevelHandler = _playerMarker?.GetComponent<PlayerXpLevelHandler>();
            gameCurrentLevel = _playerXpLevelHandler.CurrentLevel;
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

            if (!_playerXpLevelHandler) return;
            gameCurrentLevel = _playerXpLevelHandler.CurrentLevel;
        }
    }
}
