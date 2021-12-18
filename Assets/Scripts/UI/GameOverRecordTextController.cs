using TheSicker.Game;
using TMPro;
using UnityEngine;

namespace TheSicker.UI
{
    public class GameOverRecordTextController : MonoBehaviour
    {
        // cache
        GameStatsController _gameStatsController;

        private void Awake()
        {
            _gameStatsController = FindObjectOfType<GameStatsController>();

            GetComponent<TextMeshProUGUI>().text = _gameStatsController ? _gameStatsController.PlayerMaxXp.ToString() : "Not Found";
        }
    }
}
