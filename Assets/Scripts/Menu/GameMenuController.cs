using UnityEngine;

namespace TheSicker.Menu
{
    public class GameMenuController : MonoBehaviour
    {
        // cache
        AdsMenuPanelController _adsMenuPanelController;

        private void Awake()
        {
            _adsMenuPanelController = FindObjectOfType<AdsMenuPanelController>();
            _adsMenuPanelController.gameObject.SetActive(false);
        }

        public void SetAdsMenuEnabled(bool enabled)
        {
            if(!_adsMenuPanelController) return;

            _adsMenuPanelController.gameObject.SetActive(enabled);
        }
    }
}
