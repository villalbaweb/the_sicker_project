using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheSicker.Core
{
    public class VisualEffectPooledObject : MonoBehaviour, IPooledObject
    {
        // Cache
        ParticleSystem _particleSystem;

        private void Awake() 
        {
            _particleSystem = GetComponentInChildren<ParticleSystem>();   
        }

        // execute specific action on spawn
        public void OnObjectSpawn()
        {
            if(!_particleSystem) return;

            _particleSystem.Play();
        }
    }
}
