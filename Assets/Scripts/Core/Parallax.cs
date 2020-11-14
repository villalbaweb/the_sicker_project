﻿using UnityEngine;

namespace TheSicker.Core
{
    public class Parallax : MonoBehaviour
    {
        // config params
        [SerializeField] GameObject camera;
        [SerializeField] float parallaxEffect;

        private float length, startpos;

        // Start is called before the first frame update
        void Start()
        {
            startpos = transform.position.x;
            length = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            float temp = (camera.transform.position.x * (1 - parallaxEffect));
            float distance = (camera.transform.position.x * parallaxEffect);
            transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
            if (temp > startpos + length)
            {
                startpos += length;
            }
            else if (temp < startpos - length)
            {
                startpos -= length;
            }
        }
    }
}