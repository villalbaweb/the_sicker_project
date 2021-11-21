using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerInScreenHandler : MonoBehaviour
    {
        // config
        [Range(0.005f, 0.1f)]
        [SerializeField] float lowerLeftCorner = 0.005f;
        [Range(0.9f, 0.995f)]
        [SerializeField] float upperRightCorner = 0.995f;

        // cache
        Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }
        void Update()
        {
            RestrictPlayerMovementWithinScreen();
        }

        private void RestrictPlayerMovementWithinScreen()
        {
            Vector3 pos = _mainCamera.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp(pos.x, lowerLeftCorner, upperRightCorner);
            pos.y = Mathf.Clamp(pos.y, lowerLeftCorner, upperRightCorner);
            transform.position = _mainCamera.ViewportToWorldPoint(pos);
        }
    }
}
