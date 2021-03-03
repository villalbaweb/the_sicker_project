using UnityEngine;
using Cinemachine;
using TheSicker.Player;
using TheSicker.Core;

namespace TheSicker.Cameras
{
    public class CinemachineVirtualCameraSetupController : MonoBehaviour
    {
        // cache
        PlayerMarker _playerMarker;
        VirtualCameraConfinerMarker _virtualCameraCOnfinerMarker;
        CinemachineVirtualCamera _cinemachineVirtualCamera;
        CinemachineConfiner _cinemachineConfiner;

        private void Awake() 
        {
            _playerMarker = FindObjectOfType<PlayerMarker>();
            _virtualCameraCOnfinerMarker = FindObjectOfType<VirtualCameraConfinerMarker>();
            _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
            _cinemachineConfiner = GetComponent<CinemachineConfiner>();

            _cinemachineVirtualCamera.m_Follow = _playerMarker?.transform;
            _cinemachineConfiner.m_BoundingShape2D = _virtualCameraCOnfinerMarker?.GetComponent<PolygonCollider2D>();   
        }
    }
}
