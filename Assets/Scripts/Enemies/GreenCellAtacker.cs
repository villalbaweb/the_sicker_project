using UnityEngine;
using TheSicker.Core;
using TheSicker.Player;

namespace TheSicker.Enemies
{
    public class GreenCellAtacker : MonoBehaviour
    {
        // config
        [SerializeField] float chaseDistance = 4.0f;

        // Cache
        PlayerMarker _player;
        Follower _follower;

        void Update()
        {
            FindPlayer();

            SetupFollower();

            Atack(IsInAttackRange());
        }

        private void FindPlayer()
        {
            if(!_player)
            {
                _player = FindObjectOfType<PlayerMarker>();
            }
        }

        private void SetupFollower()
        {
            if(!_follower)
            {
                _follower = GetComponent<Follower>();
                _follower.target = _player.transform;
            }
        }

        private void Atack(bool isAttacking)
        {
            _follower.IsFollowing = isAttacking;
        }
        
        private bool IsInAttackRange()
        {
            return Vector2.Distance(_player.transform.position, transform.position) <= chaseDistance;
        }

        // called by Unity
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}