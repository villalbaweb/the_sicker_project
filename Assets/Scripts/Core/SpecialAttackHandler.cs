using TheSicker.Attacks;
using UnityEngine;

namespace TheSicker.Core
{
    public class SpecialAttackHandler : MonoBehaviour
    {
        // config
        [SerializeField] float timeBetweenAttacks = 5f;

        // cache
        Animator _animator;
        ISpecialAttack _specialAttack;

        // state
        float attackTimer = Mathf.Infinity;

        void Awake()
        {
            _animator = GetComponent<Animator>();
            _specialAttack = GetComponent<ISpecialAttack>();
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
                _specialAttack.Attack();
                
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
