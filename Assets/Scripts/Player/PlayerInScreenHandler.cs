using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerInScreenHandler : MonoBehaviour
    {
        // cache
        Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }
        void Update()
        {
            Vector3 pos = _mainCamera.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp01(pos.x);
            pos.y = Mathf.Clamp01(pos.y);
            transform.position = _mainCamera.ViewportToWorldPoint(pos);
        }
    }
}
