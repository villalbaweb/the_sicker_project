using UnityEngine;

namespace TheSicker.Core
{
    public class VisualEffectHandler : MonoBehaviour
    {
        // config
        [SerializeField] GameObject explosionVfxPrefab = null;

        private void StartSpecificVfx(GameObject vfxPrefab, Vector2 position)
        {
            if (!vfxPrefab) return;

            Instantiate(vfxPrefab, position, Quaternion.identity);
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
