using UnityEngine;

namespace TheSicker.Core
{
    public class VisualEffectHandler : MonoBehaviour
    {
        // config
        [SerializeField] GameObject explosionVfxPrefab = null;

        public void ExplosionVfx(Vector2 position)
        {
            if(!explosionVfxPrefab) return;

            Instantiate(explosionVfxPrefab, position, Quaternion.identity);
        }

        public void ExplosionVFXParentPosition()
        {
            ExplosionVfx(transform.position);
        }
    }
}
