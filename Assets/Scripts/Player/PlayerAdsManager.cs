using TheSicker.Menu;
using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerAdsManager : MonoBehaviour
    {
        // state
        private bool IsAdsBeenUsed = false;

        // cache
        GameMenuController _gameMenuController;
        PlayerDieSceneHandler _playerDieSceneHandler;

        private void Awake()
        {
            _gameMenuController = FindObjectOfType<GameMenuController>();
            _playerDieSceneHandler = GetComponent<PlayerDieSceneHandler>();
        }

        public void DisplayAdsButtonOnDie()
        {
            if(_gameMenuController && !IsAdsBeenUsed)
            {
                _gameMenuController.SetAdsMenuEnabled(true);
                IsAdsBeenUsed = true;
            }
            else
            {
                _playerDieSceneHandler.GameOverScreenShow();
            }
        }
    }
}
