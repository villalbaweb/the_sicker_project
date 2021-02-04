using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerBodyRendererHandler : MonoBehaviour
    {
        // config
        [SerializeField] MeshRenderer bodyMeshRenderer = null;

        public void EnableSpriteRenderer()
        {
            if (!bodyMeshRenderer) return;

            bodyMeshRenderer.enabled = true;
        }

        public void DisableSpriteRenderer()
        {
            if (!bodyMeshRenderer) return;

            bodyMeshRenderer.enabled = false;
        }
    }
}
