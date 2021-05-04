using UnityEngine;

namespace TheSicker.Core
{
    public class VisualEffectHandler : MonoBehaviour
    {
        // config
        [SerializeField] GameObject explosionVfxPrefab = null;

        // consts
        const string TEMPORARY_VISUALFX_PARENT_NAME = "Temporary Visual Effects";

        // state
        GameObject _temporaryVisualEffectsParent;

        private void Awake() 
        {
            _temporaryVisualEffectsParent = CreateTemporaryVisualEffectsParent(TEMPORARY_VISUALFX_PARENT_NAME);
        }

        private void StartSpecificVfx(GameObject vfxPrefab, Vector2 position)
        {
            if (!vfxPrefab) return;

            GameObject obj = Instantiate(vfxPrefab, position, Quaternion.identity);
            obj.transform.parent = _temporaryVisualEffectsParent.transform;
        }

        public void ExplosionVfx(Vector2 position)
        {
            StartSpecificVfx(explosionVfxPrefab, position);
        }

        public void ExplosionVFXParentPosition()
        {
            ExplosionVfx(transform.position);
        }

        private GameObject CreateTemporaryVisualEffectsParent(string parentName)
        {
            GameObject parent = GameObject.Find(parentName);

            if (!parent)
            {
                parent = new GameObject(parentName);
            }

            return parent;
        }
    }
}
