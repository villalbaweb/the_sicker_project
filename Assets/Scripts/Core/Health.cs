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

            yield return new WaitForSecondsRealtime(timeToDisableAfterDie);

            gameObject.SetActive(false);

        }
    }
}
