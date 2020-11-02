using UnityEngine;

namespace TheSicker.Core
{
    public class SpecialAttackHandler : MonoBehaviour
    {
        // TODO: Add ISpecialAttack interface so it can be handled
        // [SerializedField] ISpecialAttack specialAttack;
        
        // config
        [SerializeField] float timeBetweenAttacks = 5f;

        // cache
        Animator _animator;

        // state
        float attackTimer = Mathf.Infinity;

        void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            Attack();
        }

        private void Attack()
        {
            attackTimer += Time.deltaTime;

            if (attackTimer > timeBetweenAttacks)
            {
                // specialAttack.Attack();
                
                AnimatorTriggerAttack();

                attackTimer = 0;
            }
        }

        private void AnimatorTriggerAttack()
        {
            _animator.SetTrigger("Attack");
        }
    }
}
