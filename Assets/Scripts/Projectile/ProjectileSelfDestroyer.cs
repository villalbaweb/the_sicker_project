using TheSicker.Core;
using UnityEngine;

namespace TheSicker.Projectile
{
    public class ProjectileSelfDestroyer : MonoBehaviour, IPooledObject
    {
        // config
        [SerializeField] float destroyTime = 2;

        // state
        float instanceDestroyTime;

        // Update is called once per frame
        void Update()
        {
            SelfDestroyAfter();
        }

        private void SelfDestroyAfter()
        {
            instanceDestroyTime -= Time.deltaTime;

            if(instanceDestroyTime <= Mathf.Epsilon)
            {
                gameObject.SetActive(false);
            }
        }

        // execute specific action on spawn
        public void OnObjectSpawn()
        {
            instanceDestroyTime = destroyTime;
        }
    }
}
