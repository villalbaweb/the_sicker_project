using UnityEngine;

namespace TheSicker.Core
{
    public class VisualEffectHandler : MonoBehaviour
    {
        // config
        [SerializeField] GameObject vfxPrefab = null;

        public void StartVfx(Vector2 position)
        {
            if(!vfxPrefab) return;

            Instantiate(vfxPrefab, position, Quaternion.identity);
        }
    }
}
