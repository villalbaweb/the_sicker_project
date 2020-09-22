using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerRotation : MonoBehaviour
    {
        // config params
        [Tooltip("Rotation Config")]
        [SerializeField] float speed = 5f;
        [SerializeField] float minimunStickRotation = 0.3f;
        
        // Cached components refs
        Joystick _joystick;

        // State
        // Create a base vector for the rotation calculations
        Vector3 originVector = new Vector3(0,0,0);

        // Start is called before the first frame update
        void Awake()
        {
            _joystick = FindObjectOfType<Joystick>();
        }

        // Update is called once per frame
        void Update()
        {
            CalculateTargetPosition();
        }

        private void CalculateTargetPosition()
        {
            if(Mathf.Abs(_joystick.Horizontal) < minimunStickRotation && Mathf.Abs(_joystick.Vertical) < minimunStickRotation) { return; }

            // calculate a new Vector based on Joystick input
            Vector3 target = new Vector3(_joystick.Horizontal, _joystick.Vertical, 0);

            Vector3 vectorToTarget = target - originVector;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, CalculateStep());
        }

        private float CalculateStep()
        {
            return speed * Time.deltaTime;
        }
    }
}
