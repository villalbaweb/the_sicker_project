using UnityEngine;

namespace TheSicker.Core
{
    public class VisualEffectHandler : MonoBehaviour
    {
        // config
        [SerializeField] ObjectPoolIds visualEffectToSpawn = ObjectPoolIds.None;

        // cache
        ObjectPooler _objectPooler;

        private void Awake() 
        {
            _objectPooler = FindObjectOfType<ObjectPooler>();
        }

        private void StartSpecificVfx(Vector2 position)
        {
            _objectPooler.SpawnFromPool(visualEffectToSpawn.ToString(), position, Quaternion.identity);
        }

        public void ExplosionVfx(Vector2 position)
        {
            StartSpecificVfx(position);
        }

        public void ExplosionVFXParentPosition()
        {
            ExplosionVfx(transform.position);
        }
    }
}
