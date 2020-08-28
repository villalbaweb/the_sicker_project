using UnityEngine;

namespace TheSicker.Storm
{
    public class SafeZoneController : MonoBehaviour
    {
        // config
        [SerializeField] float shrinkSpeed = 1f;
        [SerializeField] float xShrinkStep = 0.1f;
        [SerializeField] float yShrinkStep = 0.1f;

        // state
        Vector2 _size = new Vector2();

        public Vector2 EllipseSafeZoneSize
        {
            get
            {
                _size.x = transform.localScale.x / 2;
                _size.y = transform.localScale.y / 2;

                return _size;
            }
        }

        // Update is called once per frame
        void Update()
        {
            Shrink();
        }

        private void Shrink()
        {

            float xShrinkValue = xShrinkStep * shrinkSpeed * Time.deltaTime;
            float yShrinkValue = yShrinkStep * shrinkSpeed * Time.deltaTime;

            transform.localScale -= new Vector3(xShrinkValue, yShrinkValue, 0);
        }
    }
}
