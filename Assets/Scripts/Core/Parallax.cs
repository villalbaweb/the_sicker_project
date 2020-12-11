using UnityEngine;

namespace TheSicker.Core
{
    public class Parallax : MonoBehaviour
    {
        // config params
        [SerializeField] Camera m_camera = null;
        [SerializeField] float parallaxEffect = 0.0f;

        private float lengthX, lengthY, startposX, startposY;

        // Start is called before the first frame update
        void Start()
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();

            startposX = transform.position.x;
            startposY = transform.position.y;
            lengthX = renderer.bounds.size.x;
            lengthY = renderer.bounds.size.y;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            ProcessXPosition();
            ProcessYPosition();
        }

        void ProcessXPosition()
        {
            float temp = (m_camera.transform.position.x * (1 - parallaxEffect));
            float distance = (m_camera.transform.position.x * parallaxEffect);
            transform.position = new Vector3(startposX + distance, transform.position.y, transform.position.z);
            if (temp > startposX + lengthX)
            {
                startposX += lengthX;
            }
            else if (temp < startposX - lengthX)
            {
                startposX -= lengthX;
            }
        }

        void ProcessYPosition()
        {
            float temp = (m_camera.transform.position.y * (1 - parallaxEffect));
            float distance = (m_camera.transform.position.y * parallaxEffect);
            transform.position = new Vector3(transform.position.x, startposY + distance, transform.position.z);
            if (temp > startposY + lengthY)
            {
                startposY += lengthY;
            }
            else if (temp < startposY - lengthY)
            {
                startposY -= lengthY;
            }
        }
    }
}