using UnityEngine;

namespace TheSicker.Projectile
{
    public class ProjectileSelfDestroyer : MonoBehaviour
    {
        // config
        [SerializeField] float destroyTime = 2;

        // Update is called once per frame
        void Update()
        {
            SelfDestroyAfter();
        }

        private void SelfDestroyAfter()
        {
            destroyTime -= Time.deltaTime;

            if(destroyTime <= Mathf.Epsilon)
            {
                Destroy(gameObject);
            }
        }
    }
}
