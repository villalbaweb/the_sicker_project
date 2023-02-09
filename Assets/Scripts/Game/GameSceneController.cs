using System.Collections;
using TheSicker.GameDifficulty;
using TheSicker.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheSicker.Game
{
    public class GameSceneController : MonoBehaviour
    {
        // config

        [Header("Scenes Available")]
        [SerializeField] string easyGameSceneName;
        [SerializeField] string tutorialSceneName;
        [SerializeField] string mediumGameSceneName;
        [SerializeField] string hardGameSceneName;
        [SerializeField] string gameOverSceneName;
        [SerializeField] string gameSplashSceneName;
        [SerializeField] string gameDifficultySelectionSceneName;

        [Header("Scene Transition")]
        [SerializeField] SceneTransitionController sceneTransitionController;
        [SerializeField] float timeToTransition = 2.0f;

        // cache
        GameDifficultyController _gameDifficultyController;

        private void Awake()
        {
            _gameDifficultyController = FindObjectOfType<GameDifficultyController>();
        }

        public void LoadDifficultySelectionMenu()
        {
            StartCoroutine(LoadSceneWithTransition(gameDifficultySelectionSceneName));
        }

        public void LoadPlayLevel()
        {
            StartCoroutine(LoadSceneWithTransition(GetSceneName()));
        }

        public void LoadMainMenu()
        {
            StartCoroutine(LoadSceneWithTransition(gameSplashSceneName));
        }

        public void LoadGameOver()
        {
            StartCoroutine(LoadSceneWithTransition(gameOverSceneName));
        }

        public void LoadTutorialScene()
        {
            StartCoroutine(LoadSceneWithTransition(tutorialSceneName));
        }

        #region Private Methods

        private IEnumerator LoadSceneWithTransition(string scene)
        {
            sceneTransitionController.StartSceneAwayTransitionAnimation();

            yield return new WaitForSeconds(timeToTransition);

            SceneManager.LoadScene(scene);
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
