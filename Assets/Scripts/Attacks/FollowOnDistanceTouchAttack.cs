using UnityEngine;
using TheSicker.Core;
using System.Collections;

namespace TheSicker.Attacks
{
    public class FollowOnDistanceTouchAttack : MonoBehaviour
    {
        // config
        [SerializeField] int defaultTouchDamagePerPeriod = 10;
        [SerializeField] float touchDamagePeriodRate = 2.0f;

        // state
        Coroutine _touchDamageCoroutine = null;
        Health _health;
        SpecialEffectsHandler _specialEffectsHandler;
        ContactPoint2D _contactPoint;

        // cache
        WaitForSeconds _crashDamageWaitForSeconds;
        FollowOnDistanceTouchAttackProvider _followOnDistanceTouchAttackProvider;

        private void Awake() 
        {
            _specialEffectsHandler = GetComponent<SpecialEffectsHandler>();
            _followOnDistanceTouchAttackProvider = GetComponent<FollowOnDistanceTouchAttackProvider>();
            _crashDamageWaitForSeconds = new WaitForSeconds(touchDamagePeriodRate);
        }

        private void OnCollisionStay2D(Collision2D other) 
        {
            if (other.gameObject.tag != "Player") return;

            GetCollisionContactPoint(other);
            
            GetPlayerReference(other.gameObject);

            HandleTouchAttack();

        }

        private void OnCollisionExit2D(Collision2D other) 
        {
            if (other.gameObject.tag != "Player") return;

            StopTouchAttack();
        }

        private void GetCollisionContactPoint(Collision2D other)
        {
            _contactPoint = other.GetContact(0);
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
                int damage = _followOnDistanceTouchAttackProvider ? _followOnDistanceTouchAttackProvider.GetTouchAttackDamage() : defaultTouchDamagePerPeriod;
                _health.TakeDamage(damage);
                _specialEffectsHandler.PlaySpecialEffectsOnPosition(_contactPoint.point);
                yield return _crashDamageWaitForSeconds;
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