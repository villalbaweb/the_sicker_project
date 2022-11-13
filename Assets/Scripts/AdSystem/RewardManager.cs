using TheSicker.Core;
using TheSicker.Menu;
using TheSicker.Player;
using UnityEngine;

namespace TheSicker.AdSystem
{
    public class RewardManager : MonoBehaviour
    {
        // cache
        PlayerAdsManager _playerAdsManager;
        GameMenuController _gameMenuController;

        private void Awake()
        {
            _playerAdsManager = FindObjectOfType<PlayerAdsManager>();
            _gameMenuController = FindObjectOfType<GameMenuController>();
        }

        public void GrandReward()
        {
            if (!_playerAdsManager) return;

            _gameMenuController?.SetAdsMenuEnabled(false);

            _playerAdsManager.gameObject.SetActive(true);
            _playerAdsManager.GetComponent<Health>().RestoreInitialHealth();

            print("Reward granted!!!");
        }
    }
}
