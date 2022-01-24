using UnityEngine;
using Cinemachine;

namespace TheSicker.Cameras
{
    public class CinemachineVirtualCameraShakeController : MonoBehaviour
    {
        // cache
        CinemachineVirtualCamera _cinemachineVirtualCamera;
        CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin;

        // state
        float shakeTimeLeft;
        float shakeTotalTime;
        float startingIntensity;

        #region Unity Events

        private void Awake()
        {
            _cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
            _cinemachineBasicMultiChannelPerlin = _cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        }

        private void Update()
        {
            if(shakeTimeLeft > Mathf.Epsilon)
            {
                shakeTimeLeft -= Time.deltaTime;

                float timeLeftBasedIntensity = Mathf.Lerp(startingIntensity, 0f, (1 - (shakeTimeLeft / shakeTotalTime)));

                SetCameraShakeIntensity(timeLeftBasedIntensity);
            }
        }

        #endregion

        #region Public Method

        public void CameraShake(float intensity, float time)
        {
            SetCameraShakeIntensity(intensity);

            shakeTimeLeft = time;
            shakeTotalTime = time;
            startingIntensity = intensity;
        }

        #endregion

        #region Private Methods

        private void SetCameraShakeIntensity(float intensity)
        {
            if (!_cinemachineBasicMultiChannelPerlin) return;

            _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        }

        #endregion
    }
}
