using UnityEngine;

namespace TheSicker.Core
{
    public class TemporaryGameObjectsHandler : MonoBehaviour
    {
        // consts
        const string TEMPORARY_VISUALFX_PARENT_NAME = "Temporary Visual Effects";

        // state
        GameObject _temporaryVisualEffectsParent;

        // properties
        public Transform TemporaryObjectParentTransform => _temporaryVisualEffectsParent.transform;

        private void Awake()
        {
            int numTemporaryGameObjectsHandler = FindObjectsOfType<TemporaryGameObjectsHandler>().Length;

            if (numTemporaryGameObjectsHandler > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
                _temporaryVisualEffectsParent = CreateTemporaryVisualEffectsParent(TEMPORARY_VISUALFX_PARENT_NAME);
            }
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
