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

        public void GrantPlayerReward()
        {
            if (!_playerAdsManager) return;

            _gameMenuController?.SetAdsMenuEnabled(false);

            RestorePlayerAbilities();
        }

        private void RestorePlayerAbilities()
        {
            _playerAdsManager.gameObject.SetActive(true);
            _playerAdsManager.GetComponent<Health>().RestoreInitialHealth();
            _playerAdsManager.GetComponent<PlayerMover>().RestoreMovementAbility();
            _playerAdsManager.GetComponent<PlayerShooter>().RestoreShootingAbility();
            _playerAdsManager.GetComponent<PlayerBackToLifeVisualEffectHandler>().PlayBackToLifeParticles();
        }
    }
}
