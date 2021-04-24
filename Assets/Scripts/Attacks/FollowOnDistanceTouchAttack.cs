using UnityEngine;
using TheSicker.Core;
using System.Collections;

namespace TheSicker.Attacks
{
    public class FollowOnDistanceTouchAttack : MonoBehaviour
    {
        // config
        [SerializeField] int touchDamagePerPeriod = 10;
        [SerializeField] float touchDamagePeriodRate = 2.0f;

        // state
        Coroutine _touchDamageCoroutine = null;
        Health _health;
        SpecialEffectsHandler _specialEffectsHandler;

        private void Awake() 
        {
            _specialEffectsHandler = GetComponent<SpecialEffectsHandler>();
        }

        private void OnCollisionStay2D(Collision2D other) 
        {
            if (other.gameObject.tag != "Player") return;

            GetPlayerReference(other.gameObject);

            HandleTouchAttack();

        }

        private void OnCollisionExit2D(Collision2D other) 
        {
            if (other.gameObject.tag != "Player") return;

            StopTouchAttack();
        }

        private void GetPlayerReference(GameObject player)
        {
            _health = _health ?? player?.GetComponent<Health>();
        }

        private void HandleTouchAttack()
        {
            _touchDamageCoroutine = _touchDamageCoroutine ?? StartCoroutine(CrashDamageCoroutine());
        }

        private IEnumerator CrashDamageCoroutine()
        {
            while(true)
            {
                _health.TakeDamage(touchDamagePerPeriod);
                _specialEffectsHandler.PlaySpecialEffects();
                yield return new WaitForSeconds(touchDamagePeriodRate);
            }
        }

        private void StopTouchAttack()
        {
            if(_touchDamageCoroutine == null) return;

            StopCoroutine(_touchDamageCoroutine);
            _touchDamageCoroutine = null;
        }
    }
}