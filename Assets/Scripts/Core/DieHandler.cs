using System.Collections;
using UnityEngine;

namespace TheSicker.Core
{
    public class DieHandler : MonoBehaviour
    {
        // config
        [SerializeField] float timeToDisableAfterDie = 1.5f;

        // cache
        Rigidbody2D _rigidBody2D;

        private void Awake()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
        }

        private IEnumerator DieCoroutine()
        {
            _rigidBody2D.simulated = false;

            yield return new WaitForSecondsRealtime(timeToDisableAfterDie);

            _rigidBody2D.simulated = true;
            gameObject.SetActive(false);
        }

        public void Die()
        {
            StartCoroutine(DieCoroutine());
        }
    }
}