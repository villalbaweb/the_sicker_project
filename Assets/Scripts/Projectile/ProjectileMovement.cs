using UnityEngine;

namespace TheSicker.Projectile
{
    public class ProjectileMovement : MonoBehaviour
    {
        // config
        [SerializeField] float speed = 20f;

        // Update is called once per frame
        void Update()
        {
            MoveForward(speed);
        }

        private void MoveForward(float step)
        {
            transform.position += transform.right * step * Time.deltaTime;
        }

        public void SetRotation(Quaternion rotation)
        {
            transform.rotation = rotation;
        }
    }
}
