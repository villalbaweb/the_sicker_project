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
        int playerCurrentLevel;

        // properties
        public int PlayerCurrentLevel => playerCurrentLevel;

        private void Awake()
        {
            _playerMarker = FindObjectOfType<PlayerMarker>();
            _playerXpLevelHandler = _playerMarker?.GetComponent<PlayerXpLevelHandler>();
            playerCurrentLevel = _playerXpLevelHandler.CurrentLevel;
        }

        private void OnEnable()
        {
            _playerXpLevelHandler.OnLevelUpEvent += OnPlayerLevelUp;
        }

        private void OnDisable()
        {
            _playerXpLevelHandler.OnLevelUpEvent -= OnPlayerLevelUp;
        }

        private void OnPlayerLevelUp()
        {

            if (!_playerXpLevelHandler) return;
            playerCurrentLevel = _playerXpLevelHandler.CurrentLevel;
        }
    }
}
