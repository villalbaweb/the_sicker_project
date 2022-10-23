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
        [SerializeField] string mediumGameSceneName;
        [SerializeField] string hardGameSceneName;
        [SerializeField] string gameOverSceneName;
        [SerializeField] string gameSplashSceneName;
        [SerializeField] string gameDifficultySelectionSceneName;

        [Header("Scene Transition")]
        [SerializeField] SceneTransitionController sceneTransitionController;
        [SerializeField] float timeToTransition = 2.0f;

        [Header("Game Over Control")]
        [SerializeField] float timeToGameOverLoad = 3.0f;

        // cache
        GameDifficultyController _gameDifficultyController;

        private void Awake()
        {
            int numGameSceneController = FindObjectsOfType<GameSceneController>().Length;

            if (numGameSceneController > 1)
                Destroy(gameObject);
            else
                DontDestroyOnLoad(gameObject);


            _gameDifficultyController = FindObjectOfType<GameDifficultyController>();
        }

        public void LoadDifficultySelectionMenu()
        {
            StartCoroutine(LoadSceneWithTransition(gameDifficultySelectionSceneName));
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

        private IEnumerator LoadSceneWithTransition(string scene)
        {
            sceneTransitionController.StartSceneAwayTransitionAnimation();

            yield return new WaitForSeconds(timeToTransition);

            SceneManager.LoadScene(scene);

            sceneTransitionController.StartSceneInTransitionAnimation();
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
