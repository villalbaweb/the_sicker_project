using System.Collections;
using TheSicker.GameDifficulty;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheSicker.Game
{
    public class GameSceneController : MonoBehaviour
    {
        // config

        [Header("Scenes Available")]
        [SerializeField] string easyGameSceneName;
        [SerializeField] string mediumGameSceneName;
        [SerializeField] string hardGameSceneName;
        [SerializeField] string gameOverSceneName;
        [SerializeField] string gameSplashSceneName;

        [Header("Game Over Control")]
        [SerializeField] float timeToGameOverLoad = 3.0f;

        // cache
        GameDifficultyController _gameDifficultyController;

        private void Awake()
        {
            _gameDifficultyController = FindObjectOfType<GameDifficultyController>();
        }

        public void LoadPlayLevel()
        {
            SceneManager.LoadScene(GetSceneName());
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(gameSplashSceneName);
        }

        public void LoadGameOver()
        {
            StartCoroutine(LoadGameOverLevel());
        }

        #region Private Methods

        private IEnumerator LoadGameOverLevel()
        {
            yield return new WaitForSeconds(timeToGameOverLoad);
            SceneManager.LoadScene(gameOverSceneName);
        }

        private string GetSceneName()
        {
            if (!_gameDifficultyController) return easyGameSceneName;

            switch (_gameDifficultyController.GetSelectedDifficultyLevel())
            {
                case DifficultyLevel.Easy: 
                    return easyGameSceneName;

                case DifficultyLevel.Medium:
                    return mediumGameSceneName;

                case DifficultyLevel.Hard:
                    return hardGameSceneName;

                default:   
                    return easyGameSceneName;
            }
        }

        #endregion
    }
}
