using TheSicker.Game;
using UnityEngine;

namespace TheSicker.Menu
{
    public class GameMenuController : MonoBehaviour
    {
        // cache
        AdsMenuPanelController _adsMenuPanelController;
        GameMenuPanelController _gameMenuPanelController;
        GameSceneController _gameSceneController;

        private void Awake()
        {
            _adsMenuPanelController = FindObjectOfType<AdsMenuPanelController>();
            _gameMenuPanelController= FindObjectOfType<GameMenuPanelController>();
            _gameSceneController = FindObjectOfType<GameSceneController>();

            _adsMenuPanelController.gameObject.SetActive(false);
            _gameMenuPanelController.gameObject.SetActive(false);
        }

        #region Public Methods

        public void DeclineAdsView()
        {
            SetAdsMenuEnabled(false);
            _gameSceneController?.LoadGameOver();
        }

        public void SetAdsMenuEnabled(bool enabled)
        {
            if(!_adsMenuPanelController) return;

            _adsMenuPanelController.gameObject.SetActive(enabled);
        }

        public void SetGameMenuEnabled(bool enabled)
        {
            if(!_gameMenuPanelController) return;

            _gameMenuPanelController.gameObject.SetActive(enabled);
        }

        #endregion
    }
}
