using TheSicker.Core;
using UnityEngine;

namespace TheSicker.Attacks
{
    public class FollowOnDistanceAttackerSpecialAttack : MonoBehaviour, ISpecialAttack
    {
        // cache
        ObjectPooler _objectPooler;

        private void Awake()
        {   
            _objectPooler = FindObjectOfType<ObjectPooler>();
        }

        // This is the Attack implementation
        public void Attack()
        {
            _objectPooler.SpawnFromPool(ObjectPoolIds.FollowOnDistanceSmallAttacker.ToString(), gameObject.transform.position, Quaternion.identity);
        }
    }
}
