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

        private void FixedUpdate()
        {
            HasEdgeCollission(transform.right);
            HasEdgeCollission((transform.up + transform.right).normalized);
            HasEdgeCollission(transform.up);
            HasEdgeCollission((transform.up - transform.right).normalized);
            HasEdgeCollission(-transform.right);
            HasEdgeCollission((-transform.up - transform.right).normalized);
            HasEdgeCollission(-transform.up);
            HasEdgeCollission((transform.right - transform.up).normalized);
        }

        private void HasEdgeCollission(Vector2 direction)
        {
            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, direction, rayCastDistance, edgeLayers);

            if (raycastHit.collider != null && IsInLayerMask(raycastHit.collider.gameObject.layer, edgeLayers))
            {
                print($"OnEdgeDetected invoked direction {direction}...");
                OnEdgeDetected?.Invoke();
            }
        }

        private bool IsInLayerMask(int layer, LayerMask layermask)
        {
            return layermask == (layermask | (1 << layer));
        }

    }
}
