using System.Collections;
using TheSicker.Core;
using UnityEngine;

namespace TheSicker.Player
{
    [RequireComponent(typeof(Health))]
    public class PlayerCrashHandler : MonoBehaviour
    {
        // config
        [Tooltip("Layer names that cause damage on crash")]
        [SerializeField] LayerMask crashLayers = new LayerMask();

        [SerializeField] int crashDamagePerSecond = 10;
        [SerializeField] float crashDamageSecondsRate = 2.0f;

        // cache
        CapsuleCollider2D _capsuleCollider2D;
        Health _health;

        // state
        Coroutine _crashDamageCoroutine = null;

        void Start()
        {
            _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
            _health = GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {
            Crash();
        }

        private void Crash()
        {
            if(IsTouchingCrashLayers())
            {
                _crashDamageCoroutine = _crashDamageCoroutine ?? StartCoroutine(CrashDamageCoroutine());
            }
            else if(_crashDamageCoroutine != null)
            {
                StopCoroutine(_crashDamageCoroutine);
                _crashDamageCoroutine = null;
            }
        }

        private bool IsTouchingCrashLayers()
        {
            return _capsuleCollider2D ? _capsuleCollider2D.IsTouchingLayers(crashLayers) : false;
        }

        private IEnumerator CrashDamageCoroutine()
        {
            while(true)
            {
                _health.TakeDamage(crashDamagePerSecond);
                yield return new WaitForSeconds(crashDamageSecondsRate);
            }
        }
    }
}
