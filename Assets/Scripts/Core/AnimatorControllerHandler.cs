using UnityEngine;

namespace TheSicker.Core
{
    public class AnimatorControllerHandler : MonoBehaviour
    {
        // cache
        Animator _animator;

        private void Awake() 
        {
            _animator = GetComponent<Animator>();    
        }

        public void RunDieAnimation()
        {
            _animator.SetTrigger("Die");
            //_animator.ResetTrigger("Die");
        }
    }
}
