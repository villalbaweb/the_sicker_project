using TheSicker.Core;
using TheSicker.Player;
using UnityEngine;

namespace TheSicker.Enemies
{
    public class StopOnDistanceAttackerHandler : MonoBehaviour
    {
        // config
        [SerializeField] float stopDistance = 5.0f;

        // Cache
        PlayerMarker _player;
        Follower _follower;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerMarker>();
            _follower = GetComponent<Follower>();
        }

        void Update()
        {
            print($"is in range to stop ... {IsInAttackRange()}");
        }

        private bool IsInAttackRange()
        {
            bool isInStopRange = Vector2.Distance(_player.transform.position, transform.position) <= stopDistance;
            return isInStopRange;
        }

        // called by Unity
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, stopDistance);
        }
    }
}
