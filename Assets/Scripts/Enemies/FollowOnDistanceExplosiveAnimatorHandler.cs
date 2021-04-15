using UnityEngine;

namespace TheSicker.Enemies
{
    public class FollowOnDistanceExplosiveAnimatorHandler : MonoBehaviour
    {
        // cache
        Animator _animator;

        private void Awake() 
        {
            _animator = GetComponent<Animator>();    
        }

        public void SetIsAttackingAnimation(bool isAttacking)
        {
            _animator.SetBool("IsAttacking", isAttacking);
        }
    }
}
