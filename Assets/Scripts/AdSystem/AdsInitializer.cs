using TheSicker.Menu;
using UnityEngine;
using UnityEngine.Advertisements;

namespace TheSicker.AdSystem
{
    public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
    {
        [SerializeField] string _androidGameId;
        [SerializeField] string _iOSGameId;
        [SerializeField] bool _testMode = true;
        private string _gameId;

        // cache
        RewardedAdsButton _rewardedAdsButton;
        GameMenuController _gameMenuController;

        void Awake()
        {
            InitializeAds();

            _gameMenuController = FindObjectOfType<GameMenuController>();
            _gameMenuController.SetAdsMenuEnabled(true);
            
            _rewardedAdsButton = FindObjectOfType<RewardedAdsButton>();
        }

        public void InitializeAds()
        {
            _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
                ? _iOSGameId
                : _androidGameId;
            Advertisement.Initialize(_gameId, _testMode, this);
        }

        public void OnInitializationComplete()
        {
            Debug.Log("Unity Ads initialization complete.");
            _rewardedAdsButton?.LoadAd();

            _gameMenuController.SetAdsMenuEnabled(false);
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
        }
    }
}
