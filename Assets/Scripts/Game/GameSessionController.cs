using UnityEngine;

namespace TheSicker.Game
{
    public class GameSessionController : MonoBehaviour
    {
        private void Awake()
        {
            int numGameSessions = FindObjectsOfType<GameSessionController>().Length;

            if (numGameSessions > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
