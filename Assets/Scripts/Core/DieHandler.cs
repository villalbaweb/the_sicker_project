using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace TheSicker.Core
{
    public class DieHandler : MonoBehaviour
    {
        // config
        [SerializeField] float timeToDisableAfterDie = 1.5f;
        [SerializeField] UnityEvent onStartDieCoroutineEvent = null;
        [SerializeField] UnityEvent onCompleteDieCoroutineEvent = null;

        // cache
        Rigidbody2D _rigidBody2D;
        WaitForSecondsRealtime _dieWaitForSeconds;

        private void Awake()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _dieWaitForSeconds = new WaitForSecondsRealtime(timeToDisableAfterDie);
        }

        // Common actions to be executed when die
        private IEnumerator DieCoroutine()
        {
            onStartDieCoroutineEvent.Invoke();

            _rigidBody2D.simulated = false;

            yield return _dieWaitForSeconds;

            _rigidBody2D.simulated = true;
            gameObject.SetActive(false);

            onCompleteDieCoroutineEvent.Invoke();
        }

        public void Die()
        {
            StartCoroutine(DieCoroutine());
        }
    }
}