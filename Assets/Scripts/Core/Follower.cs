using UnityEngine;

namespace TheSicker.Core
{
    public class Follower : MonoBehaviour
    {
        // config params
        [Tooltip("Follower' Speed")]
        [SerializeField] float speed = 5f;
        [Tooltip("Follower's Target")]
        [SerializeField] public Transform target;
        [SerializeField] bool isFollowing = false;

        // properties
        public bool IsFollowing 
        { 
            get
            {
                return isFollowing;
            }

            set
            {
                isFollowing = value;
            } 
        }

        // Update is called once per frame
        void Update()
        {
            float step = CalculateStep();

            if (isFollowing)
            {
                CalculateTargetPosition(step);
            }

            MoveRight(step);
        }

        private void MoveRight(float step)
        {
            transform.position += transform.right * step;
        }

        private void CalculateTargetPosition(float step)
        {
            Vector3 vectorToTarget = target.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, step);
        }

        private float CalculateStep()
        {
            return speed * Time.deltaTime;
        }
    }
}