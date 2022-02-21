using TheSicker.Game;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TheSicker.Menu
{
    public class MainMenuButtonController : MonoBehaviour, IPointerDownHandler
    {
        // cache
        GameSceneController _gameSceneController;
        PauseButtonController _pauseButtonController;

        #region Private Methods

        private void Awake()
        {
            _gameSceneController = FindObjectOfType<GameSceneController>();
            _pauseButtonController = FindObjectOfType<PauseButtonController>();
        }

        #endregion


        #region IPointerDownHandler Implementation 

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!_pauseButtonController || !_gameSceneController) return;

            _pauseButtonController.PauseButtonClick();
            _gameSceneController.LoadMainMenu();
        }

        #endregion
    }
}
