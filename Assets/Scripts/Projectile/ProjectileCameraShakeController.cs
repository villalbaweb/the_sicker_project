using TheSicker.Cameras;
using UnityEngine;

namespace TheSicker.Projectile
{
    public class ProjectileCameraShakeController : MonoBehaviour
    {
        // config
        [SerializeField] 
        [Range(0f, 10f)]
        float cameraShakeIntensity = 1.0f;

        [SerializeField]
        [Range(0f, 1f)]
        float cameraShakeTime = 0.1f;

        // cache
        CinemachineVirtualCameraShakeController _cinemachineVirtualCameraShakeController;

        private void Awake()
        {
            _cinemachineVirtualCameraShakeController = FindObjectOfType<CinemachineVirtualCameraShakeController>();
        }

        #region Public Methods

        public void CameraShake()
        {
            if (!_cinemachineVirtualCameraShakeController) return;

            _cinemachineVirtualCameraShakeController.CameraShake(cameraShakeIntensity, cameraShakeTime);
        }

        #endregion
    }
}
