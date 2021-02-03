using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerBodyRendererHandler : MonoBehaviour
    {
        // config
        [SerializeField] MeshRenderer bodyMeshRenderer = null;

        // cache
        MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = bodyMeshRenderer.GetComponent<MeshRenderer>();
        }

        public void EnableSpriteRenderer()
        {
            if (!_meshRenderer) return;

            _meshRenderer.enabled = true;
        }

        public void DisableSpriteRenderer()
        {
            if (!_meshRenderer) return;

            _meshRenderer.enabled = false;
        }
    }
}
