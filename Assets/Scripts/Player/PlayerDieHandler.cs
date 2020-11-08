using TheSicker.Core;
using UnityEngine;

namespace TheSicker.Player
{
    // Specific actions to be executed when die
    public class PlayerDieHandler : MonoBehaviour
    {
        // cache
        BodySpriteRendererHandler _bodySpriteRendererHandler;
        PlayerEngineParticleEffectsStopper _playerEngineParticleEffectsStopper;

        private void Awake() 
        {
            _bodySpriteRendererHandler = GetComponent<BodySpriteRendererHandler>();
            _playerEngineParticleEffectsStopper = GetComponent<PlayerEngineParticleEffectsStopper>();    
        }

        public void OnStartDieCoroutine()
        {
            _bodySpriteRendererHandler.DisableSpriteRenderer();
            _playerEngineParticleEffectsStopper.EngineParticleSystemsTurnOff();
        }

        public void OnCompleteDieCoroutine()
        {
            _bodySpriteRendererHandler.EnableSpriteRenderer();
        }
    }
}