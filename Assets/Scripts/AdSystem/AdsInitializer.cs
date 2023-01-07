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
            _gameMenuController = FindObjectOfType<GameMenuController>();

            // Retrieve RewardedAdsButton, this belongs to GameMenuController component 
            _gameMenuController.SetAdsMenuEnabled(true);
            _rewardedAdsButton = FindObjectOfType<RewardedAdsButton>();
            _gameMenuController.SetAdsMenuEnabled(false);

        }

        private void Start()
        {
            AdsStartUp();
        }

        public void OnInitializationComplete()
        {
            Debug.Log("Unity Ads initialization complete.");
            LoadNewAd();
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
        }

        private void AdsStartUp()
        {
            if(!Advertisement.isInitialized)
            {
                InitializeAds();
            }
            else
            {
                LoadNewAd();
            }
        }

        private void InitializeAds()
        {
            _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
                ? _iOSGameId
                : _androidGameId;
            Advertisement.Initialize(_gameId, _testMode, this);
        }

        private void LoadNewAd()
        {
            _rewardedAdsButton?.LoadAd();
        }
    }
}
