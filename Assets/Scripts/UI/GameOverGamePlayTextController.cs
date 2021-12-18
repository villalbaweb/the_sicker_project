using TheSicker.Game;
using TMPro;
using UnityEngine;

namespace TheSicker.UI
{
    public class GameOverGamePlayTextController : MonoBehaviour
    {
        // cache
        GameStatsController _gameStatsController;

        private void Awake()
        {
            _gameStatsController = FindObjectOfType<GameStatsController>();

            GetComponent<TextMeshProUGUI>().text = _gameStatsController ? _gameStatsController.PlayerXp.ToString() : "Not Found";
        }
    }
}
