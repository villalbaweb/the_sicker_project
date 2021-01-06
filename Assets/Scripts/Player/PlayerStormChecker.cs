using TheSicker.Core;
using TheSicker.Storm;
using System.Collections;
using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerStormChecker : MonoBehaviour
    {
        // config
        [SerializeField] int stormDamagePerSecond = 1;
        [SerializeField] float stormDamageSecondsRate = 2.0f;

        // cache
        SafeZoneController _safeZone;
        Health _health;

        // state
        Coroutine _stormDamageCoroutine = null;

        // Start is called before the first frame update
        void Awake()
        {
            _safeZone = FindObjectOfType<SafeZoneController>();
            _health = GetComponent<Health>();
        }

        // Update is called once per frame
        void Update()
        {
            StormDamage();
        }

        private void StormDamage()
        {
            if(!IsInSafeZone())
            {
                _stormDamageCoroutine = _stormDamageCoroutine ?? StartCoroutine(StormDamageCoroutine());
            }
            else if(_stormDamageCoroutine != null)
            {
                StopCoroutine(_stormDamageCoroutine);
                _stormDamageCoroutine = null;
            }
        }

        private bool IsInSafeZone()
        {
            if(!_safeZone) { return true; }

            Vector2 safeZoneSize = _safeZone.EllipseSafeZoneSize;

            return Mathf.Abs(transform.position.x) <= safeZoneSize.x && Mathf.Abs(transform.position.y) <= safeZoneSize.y;
        }

        private IEnumerator StormDamageCoroutine()
        {
            while(true)
            {
                print("TakeDamage from coroutine...");

                _health.TakeDamage(stormDamagePerSecond);
                yield return new WaitForSeconds(stormDamageSecondsRate);
            }
        }
    }
}
