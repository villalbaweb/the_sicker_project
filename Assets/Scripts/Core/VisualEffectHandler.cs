using UnityEngine;

namespace TheSicker.Core
{
    public class VisualEffectHandler : MonoBehaviour
    {
        // config
        [SerializeField] GameObject explosionVfxPrefab = null;

        // cache
        TemporaryGameObjectsHandler _temporaryGameObjectsHandler;

        private void Awake() 
        {
            _temporaryGameObjectsHandler = FindObjectOfType<TemporaryGameObjectsHandler>();
        }

        private void StartSpecificVfx(GameObject vfxPrefab, Vector2 position)
        {
            if (!vfxPrefab) return;

            GameObject obj = Instantiate(vfxPrefab, position, Quaternion.identity);
            obj.transform.parent = _temporaryGameObjectsHandler.TemporaryObjectParentTransform;
        }

        public void ExplosionVfx(Vector2 position)
        {
            StartSpecificVfx(explosionVfxPrefab, position);
        }

        public void ExplosionVFXParentPosition()
        {
            ExplosionVfx(transform.position);
        }
    }
}
