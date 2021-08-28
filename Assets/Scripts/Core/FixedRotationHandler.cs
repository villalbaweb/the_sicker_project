using UnityEngine;

namespace TheSicker.Core
{
    public class FixedRotationHandler : MonoBehaviour
    {
        // cache
        Quaternion initialRotation;

        // Start is called before the first frame update
        void Awake()
        {
            initialRotation = transform.rotation;
        }

        void LateUpdate()
        {
            transform.rotation = initialRotation;
        }
    }
}
