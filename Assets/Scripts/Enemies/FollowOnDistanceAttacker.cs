using UnityEngine;
using TheSicker.Core;
using TheSicker.Player;
using UnityEngine.Events;

namespace TheSicker.Enemies
{
    public class FollowOnDistanceAttacker : MonoBehaviour, IPooledObject
    {
        // config
        [SerializeField] float chaseDistance = 4.0f;
        [SerializeField] OnRangeEvent onRangeEvent = null;

        [System.Serializable]
        public class OnRangeEvent: UnityEvent<bool> {}

        // Cache
        Health _health;
        PlayerMarker _player;
        Follower _follower;

        // state
        bool isInAttackRange;

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
            isInAttackRange = Vector2.Distance(_player.transform.position, transform.position) <= chaseDistance;
            onRangeEvent?.Invoke(isInAttackRange);
            return isInAttackRange;
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
