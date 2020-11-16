using UnityEngine;

namespace TheSicker.Core
{
    public class PlanetMovementHandler : MonoBehaviour
    {
        // config
        [Tooltip("Moving speed on Y axis in local space")]
        [SerializeField] float speed = 0.1f;
        [SerializeField] Vector3 direction = new Vector3();

        //moving the object with the defined speed
        private void Update()
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}