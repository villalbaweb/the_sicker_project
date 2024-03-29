﻿using System;
using System.Collections;
using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerMover : MonoBehaviour
    {
        // config
        [Header("Speed")]
        [SerializeField] float playerSpeed = 5;
        [SerializeField] float turboSpeedIncreaseTimes = 1.5f;
        [SerializeField] int turboSpeedTime = 3;

        [Header("Remaining Move")]
        [SerializeField] float remainMovingTime = 3f;
        [SerializeField] float remainMovingSlowFactor = 0.75f;

        // double click manual implementation
        [Header("Double Click")]
        [SerializeField] int clickTimes = 0;
        [SerializeField] float doubleClickDelay = 1.5f;

        [Header("Debug")]
        [SerializeField] bool useAdditionalMoveKey = false;

        // events
        public Action OnStartMovement;
        public Action OnStopMovement;
        public Action OnTurboSpeedStart;
        public Action OnTurboSpeedStop;

        // state
        bool isDead;
        bool IsMoveBtnPressed;
        bool IsMoveBtnReleased;
        bool IsTurboSpeed = false;
        bool IsKeepMoving = false;
        float remainMovingTimeLeft;
        Vector3 remainMovementDirection;
        float remainMovingSpeed;
        float playerGameSpeed;
        float doubleclickTimeLeft;

        // cache
        WaitForSeconds _turboSpeedWaitForSeconds;

        private void Awake() 
        {
            _turboSpeedWaitForSeconds = new WaitForSeconds(turboSpeedTime);
            playerGameSpeed = playerSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            if(isDead) return;

            TurboTimeLeftCheck();
            ThrottleMove();
            RemainMove();
        }

        private void ThrottleMove()
        {
            if(IsMoveBtnPressed || (useAdditionalMoveKey && Input.GetKey(KeyCode.Z)))
            {
                OnStartMovement?.Invoke();
                if(IsTurboSpeed)
                {
                    OnTurboSpeedStart?.Invoke();
                }

                IsKeepMoving = false;
                MoveForward();
            }
        }

        private void RemainMove()
        {
            if(IsMoveBtnReleased || (useAdditionalMoveKey && Input.GetKeyUp(KeyCode.Z)))
            {
                OnStopMovement?.Invoke();
                IsMoveBtnReleased = false;
                IsKeepMoving = true;
                remainMovingTimeLeft = remainMovingTime;
                remainMovementDirection = transform.right;
                remainMovingSpeed = playerGameSpeed;
            }

            if(IsKeepMoving && remainMovingTimeLeft > Mathf.Epsilon) 
            {
                MoveRemain(remainMovingSpeed);
                remainMovingTimeLeft -= Time.deltaTime;
                remainMovingSpeed -= (remainMovingSpeed * remainMovingSlowFactor * Time.deltaTime);
            }
        }
        
        private void MoveForward()
        {
            transform.position += transform.right * playerGameSpeed * Time.deltaTime;
        }

        private void MoveRemain(float remainingMovingSpeed)
        {
            transform.position += remainMovementDirection * remainingMovingSpeed * Time.deltaTime;
        }

        private IEnumerator TurboSpeedCoroutine()
        {
            float originalSpeed = playerGameSpeed;

            IsTurboSpeed = true;
            playerGameSpeed = playerGameSpeed * turboSpeedIncreaseTimes;

            yield return _turboSpeedWaitForSeconds;

            playerGameSpeed = originalSpeed;
            IsTurboSpeed = false;
            OnTurboSpeedStop?.Invoke();
        }

        public void OnDie()
        {
            isDead = true;
        }

        public void RestoreMovementAbility()
        {
            isDead = false;
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

            if (!IsTurboSpeed && clickTimes == 1)
            {
                doubleclickTimeLeft = doubleClickDelay;
            }
            else if (!IsTurboSpeed && clickTimes > 1 && IsDoubleClickOnTime())
            {
                clickTimes = 0;
                doubleclickTimeLeft = 0;

                StartCoroutine(TurboSpeedCoroutine());
            }
            else if (clickTimes > 2)
            {
                clickTimes = 0;
                doubleclickTimeLeft = 0;
            } 
        }

        private bool IsDoubleClickOnTime()
        {
            return doubleclickTimeLeft > Mathf.Epsilon;
        }

        private void TurboTimeLeftCheck()
        {
            if (doubleclickTimeLeft < Mathf.Epsilon)
            {
                clickTimes = 0;
                return;
            }

            doubleclickTimeLeft -= Time.deltaTime;
        }

        #endregion
    }
}
