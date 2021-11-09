using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace TheSicker.Player
{
    public class PlayerGameAreaEdgeDetector : MonoBehaviour
    {
        // config
        [SerializeField] LayerMask edgeLayers = new LayerMask();
        [SerializeField] float rayCastDistance = 1f;
        [SerializeField] UnityEvent OnEdgeDetected = new UnityEvent();

        // state
        List<Vector2> directionsToCheck;

        private void Awake()
        {
            directionsToCheck = new List<Vector2>
            {
                transform.right,
                (transform.up + transform.right).normalized,
                transform.up,
                (transform.up - transform.right).normalized,
                -transform.right,
                (-transform.up - transform.right).normalized,
                -transform.up,
                (transform.right - transform.up).normalized
            };
        }

        private void FixedUpdate()
        {
            EdgeDetectionMechanism();
        }

        private void EdgeDetectionMechanism()
        {
            foreach(Vector2 direction in directionsToCheck)
            {
                if(HasEdgeCollission(direction))
                {
                    return;
                }
            }
        }

        private bool HasEdgeCollission(Vector2 direction)
        {
            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, direction, rayCastDistance, edgeLayers);

            if (raycastHit.collider != null && IsInLayerMask(raycastHit.collider.gameObject.layer, edgeLayers))
            {
                OnEdgeDetected?.Invoke();
                return true;
            }

            return false;
        }

        private bool IsInLayerMask(int layer, LayerMask layermask)
        {
            return layermask == (layermask | (1 << layer));
        }

    }
}
