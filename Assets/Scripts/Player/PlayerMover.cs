using System.Collections;
using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerMover : MonoBehaviour
    {
        // config
        [Header("VFX")]
        [SerializeField] ParticleSystem engineParticleSystem = null;
        [SerializeField] ParticleSystem speedEngineParticleSystem = null;

        [Header("Speed")]
        [SerializeField] float speed = 5;
        [SerializeField] int turboSpeedIncreaseTimes = 3;
        [SerializeField] int turboSpeedTime = 3;

        [Header("Remaining Move")]
        [SerializeField] float remainMovingTime = 3f;
        [SerializeField] float remainMovingSlowFactor = 0.75f;

        // double click manual implementation
        [Header("Double Click")]
        [SerializeField] int clickTimes = 0;
        [SerializeField] float clickedTime;
        [SerializeField] float doubleClickDelay = 1.5f;

        [Header("Debug")]
        [SerializeField] bool useAdditionalMoveKey = false;

        // state
        bool IsMoveBtnPressed;
        bool IsMoveBtnReleased;
        bool IsTurboSpeed = false;
        bool IsKeepMoving = false;
        float remainMovingTimeLeft;
        Vector2 remainMovementDirection;
        float remainMovingSpeed;

        // Update is called once per frame
        void Update()
        {
            ThrottleMove();
            RemainMove();
            UpdateParticleSystems();
        }

        private void ThrottleMove()
        {
            if(IsMoveBtnPressed || (useAdditionalMoveKey && Input.GetKey(KeyCode.Z)))
            {   
                IsKeepMoving = false;
                MoveForward();
            }
        }

        private void RemainMove()
        {
            if(IsMoveBtnReleased || (useAdditionalMoveKey && Input.GetKeyUp(KeyCode.Z)))
            {
                IsMoveBtnReleased = false;
                IsKeepMoving = true;
                remainMovingTimeLeft = remainMovingTime;
                remainMovementDirection = transform.right;
                remainMovingSpeed = speed;
            }

            if(IsKeepMoving && remainMovingTimeLeft > Mathf.Epsilon) 
            {
                MoveRemain(remainMovingSpeed);
                remainMovingTimeLeft -= Time.deltaTime;
                remainMovingSpeed -= (remainMovingSpeed * remainMovingSlowFactor * Time.deltaTime);
            }
        }

        private void UpdateParticleSystems() 
        {
            if (IsMoveBtnPressed || (useAdditionalMoveKey && Input.GetKey(KeyCode.Z)))
            {
                if (!engineParticleSystem.isPlaying)
                {
                    engineParticleSystem.Play();
                }

                if (IsTurboSpeed && !speedEngineParticleSystem.isPlaying)
                {
                    speedEngineParticleSystem.Play();
                }

                if (!IsTurboSpeed && !speedEngineParticleSystem.isStopped)
                {
                    speedEngineParticleSystem.Stop();
                }
            }
            else
            {
                if (!engineParticleSystem.isStopped)
                {
                    engineParticleSystem.Stop();
                }

                if (!speedEngineParticleSystem.isStopped)
                {
                    speedEngineParticleSystem.Stop();
                }
            }
        }
        
        private void MoveForward()
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }

        private void MoveRemain(float remainingMovingSpeed)
        {
            transform.Translate(remainMovementDirection * remainingMovingSpeed * Time.deltaTime, Space.World);
        }

        private IEnumerator TurboSpeedCoroutine()
        {
            float originalSpeed = speed;

            IsTurboSpeed = true;
            speed = speed * turboSpeedIncreaseTimes;

            yield return new WaitForSeconds(turboSpeedTime);

            speed = originalSpeed;
            IsTurboSpeed = false;
        }

        #region UI Button Related Methods

        public void MoveBtnDown()
        {
            DoubleClickChecker();

            IsMoveBtnPressed = true;
        }

        public void MoveBtnUp()
        {
            IsMoveBtnPressed = false;
            IsMoveBtnReleased = true;
        }

        private void DoubleClickChecker()
        {
            clickTimes++;

            if (clickTimes == 1)
            {
                clickedTime = Time.time;
            }
            else if (!IsTurboSpeed && clickTimes > 1 && IsDoubleClickOnTime())
            {
                clickTimes = 0;
                clickedTime = 0;

                StartCoroutine(TurboSpeedCoroutine());
            }
            else if (clickTimes > 2)
            {
                clickTimes = 0;
            } 
        }

        private bool IsDoubleClickOnTime()
        {
            return Time.time - clickedTime < doubleClickDelay;
        }

        #endregion
    }
}
