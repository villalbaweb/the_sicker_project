using UnityEngine;

namespace TheSicker.Core
{
    public class BodySpriteRendererHandler : MonoBehaviour
    {
        // config
        [SerializeField] GameObject body = null;

        // cache
        SpriteRenderer _spriteRenderer;

        private void Awake() 
        {
            _spriteRenderer = body.GetComponent<SpriteRenderer>();    
        }

        public void EnableSpriteRenderer()
        {
            if(!_spriteRenderer) return;

            _spriteRenderer.enabled = true;
        }

        public void DisableSpriteRenderer()
        {
            if (!_spriteRenderer) return;

            _spriteRenderer.enabled = false;
        }
    }
}