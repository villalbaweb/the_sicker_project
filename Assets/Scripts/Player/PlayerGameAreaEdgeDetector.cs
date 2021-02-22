using UnityEngine;
using UnityEngine.Events;

namespace TheSicker.Player
{
    public class PlayerGameAreaEdgeDetector : MonoBehaviour
    {
        // config
        [SerializeField] float timeBetweenEdgeDetectionCast = 0.3f;
        [SerializeField] LayerMask edgeLayers = new LayerMask();
        [SerializeField] float circleRayCastRadious = 0.5f;
        [SerializeField] float rayCastDistance = 1f;
        [SerializeField] UnityEvent OnEdgeDetected = new UnityEvent();

        // Start is called before the first frame update
        private void Start()
        {
            InvokeRepeating("GameAreaCircleCast", timeBetweenEdgeDetectionCast, timeBetweenEdgeDetectionCast);
        }

        private void GameAreaCircleCast()
        {
            // to check if Player its alive ????

            RaycastHit2D raycastHit = Physics2D.CircleCast(transform.position, circleRayCastRadious, transform.right, rayCastDistance, edgeLayers);

            if(raycastHit.collider != null && IsInLayerMask(raycastHit.collider.gameObject.layer, edgeLayers))
            {
                OnEdgeDetected?.Invoke();
            }
        }

        private bool IsInLayerMask(int layer, LayerMask layermask)
        {
            return layermask == (layermask | (1 << layer));
        }

    }
}
