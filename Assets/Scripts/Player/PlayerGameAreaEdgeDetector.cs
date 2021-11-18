using UnityEngine;
using UnityEngine.Events;

namespace TheSicker.Player
{
    public class PlayerGameAreaEdgeDetector : MonoBehaviour
    {
        // config
        [SerializeField] UnityEvent OnEdgeDetected = new UnityEvent();
        [SerializeField] UnityEvent OnEdgeLeaved = new UnityEvent();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag != "Playable Area Delimiter") return;

            OnEdgeDetected?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag != "Playable Area Delimiter") return;

            OnEdgeLeaved?.Invoke();
        }
    }
}
