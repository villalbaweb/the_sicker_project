using UnityEngine;

namespace TheSicker.Core
{
    public class Follower : MonoBehaviour
    {
        // config params
        [Tooltip("Follower' Speed")]
        [SerializeField] float normalSpeed = 5f;
        [SerializeField] float followingSpeed = 10f;
        
        [Tooltip("Follower's Target")]
        [SerializeField] public Transform target;

        // properties
        public bool IsFollowing => isFollowing;

        // state
        float speed;
        bool isMovementStopped = false;
        bool isFollowing = false;

        // Update is called once per frame
        void Update()
        {
            float step = CalculateStep();
                
            CalculateTargetPosition(step);

            MoveRight(step);
        }

        public void Following(bool isFollowingState)
        {
            isFollowing = isFollowingState;

            speed = isFollowing ? followingSpeed : normalSpeed;
        }

        public void OverideMovement(bool isOverrrideMovementRequired)
        {
            isMovementStopped = isOverrrideMovementRequired;
        }

        private float CalculateStep()
        {
            return speed * Time.deltaTime;
        }

        private void CalculateTargetPosition(float step)
        {
            if(!isFollowing) return; 

            Vector3 vectorToTarget = target.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, step);
        }

        private void MoveRight(float step)
        {
            if(isMovementStopped) return;

            transform.position += transform.right * step;
        }
    }
}