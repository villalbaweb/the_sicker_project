using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace TheSicker.Core
{
    public class Health : MonoBehaviour
    {
        // config
        [SerializeField] int health = 100;
        [SerializeField] UnityEvent onDieEvent;
        [SerializeField] float timeToDisableAfterDie = 1.5f;

        // cache
        Rigidbody2D _rigidBody2D;

        private void Awake() 
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();    
        }

        public void TakeDamage(int damage)
        {
            health -= damage;

            if(health <= Mathf.Epsilon) 
            {
               StartCoroutine(Die());
            }
        }

        private IEnumerator Die()
        {

            onDieEvent.Invoke();
            _rigidBody2D.simulated = false;

            yield return new WaitForSecondsRealtime(timeToDisableAfterDie);

            _rigidBody2D.simulated = true;
            gameObject.SetActive(false);

        }
    }
}
