using UnityEngine;

namespace TheSicker.Core
{
    public class BodySpriteRendererHandler : MonoBehaviour
    {
        // config
        [SerializeField] GameObject body = null;

        // cache
        MeshRenderer _meshRenderer;

        private void Awake() 
        {
            _meshRenderer = body.GetComponent<MeshRenderer>();    
        }

        public void EnableSpriteRenderer()
        {
            if(!_meshRenderer) return;

            _meshRenderer.enabled = true;
        }

        public void DisableSpriteRenderer()
        {
            if (!_meshRenderer) return;

            _meshRenderer.enabled = false;
        }
    }
}