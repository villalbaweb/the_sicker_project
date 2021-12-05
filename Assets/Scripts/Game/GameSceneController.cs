using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheSicker.Game
{
    public class GameSceneController : MonoBehaviour
    {
        // config

        [Header("Scenes Available")]
        [SerializeField] string gameSceneName;
        [SerializeField] string gameOverSceneName;
        [SerializeField] string gameSplashSceneName;

        [Header("Game Over Control")]
        [SerializeField] float timeToGameOverLoad = 3.0f;

        public void LoadPlayLevel()
        {
            SceneManager.LoadScene(gameSceneName);
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene(gameSplashSceneName);
        }

        public void LoadGameOver()
        {
            StartCoroutine(LoadGameOverLevel());
        }

        private IEnumerator LoadGameOverLevel()
        {
            yield return new WaitForSeconds(timeToGameOverLoad);
            SceneManager.LoadScene(gameOverSceneName);
        }
    }
}
