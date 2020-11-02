using UnityEngine;
using TheSicker.Core;
using TheSicker.Player;

namespace TheSicker.Enemies
{
    public class FollowOnDistanceAttacker : MonoBehaviour, IPooledObject
    {
        // config
        [SerializeField] float chaseDistance = 4.0f;

        // Cache
        Health _health;
        PlayerMarker _player;
        Follower _follower;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _player = FindObjectOfType<PlayerMarker>();
            _follower = GetComponent<Follower>();
            _follower.target = _player.transform;
        }

        void Update()
        {
            Atack(IsInAttackRange());
        }

        private void Atack(bool isAttacking)
        {
            _follower.Following(isAttacking);
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

        // execute specific action on spawn
        public void OnObjectSpawn()
        {
            _health.RestoreInitialHealth();
        }
    }
}
