using TheSicker.Core;
using UnityEngine;

namespace TheSicker.Player
{
    // Specific actions to be executed when die
    public class PlayerDieHandler : MonoBehaviour
    {
        // cache
        BodySpriteRendererHandler _bodySpriteRendererHandler;

        private void Awake() 
        {
            _bodySpriteRendererHandler = GetComponent<BodySpriteRendererHandler>();    
        }

        public void OnStartDieCoroutine()
        {
            _bodySpriteRendererHandler.DisableSpriteRenderer();
        }

        public void OnCompleteDieCoroutine()
        {
            _bodySpriteRendererHandler.EnableSpriteRenderer();
        }
    }
}