using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerTutorialControlHandler : MonoBehaviour
    {
        // config
        [SerializeField] bool IsTutorialPlayer = false;

        // cache
        PlayerMover _playerMover;

        private void Awake()
        {
            _playerMover = GetComponent<PlayerMover>();
        }

        private void Update()
        {
            print($"IsTutorialPlayer: {IsTutorialPlayer}");
        }
    }
}
