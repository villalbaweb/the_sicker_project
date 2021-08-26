using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheSicker.Core
{
    public class ObjectPickUpMovementHandler : MonoBehaviour
    {
        // config params
        [Tooltip("Object Pickup Speed")]
        [SerializeField] float speed = 5f;

        private void Update()
        {
            float step = CalculateStep();

            MoveRight(step);
        }

        private float CalculateStep()
        {
            return speed * Time.deltaTime;
        }

        private void MoveRight(float step)
        {
            transform.position += transform.right * step;
        }
    }
}
