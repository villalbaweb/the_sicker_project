using UnityEngine;

namespace TheSicker.Player
{
    // Specific actions to be executed when die
    public class PlayerDieHandler : MonoBehaviour
    {
        // cache
        PlayerBodyRendererHandler _bodyRendererHandler;
        PlayerEngineParticleEffectsStopper _playerEngineParticleEffectsStopper;

        private void Awake() 
        {
            _bodyRendererHandler = GetComponent<PlayerBodyRendererHandler>();
            _playerEngineParticleEffectsStopper = GetComponent<PlayerEngineParticleEffectsStopper>();    
        }

        public void OnStartDieCoroutine()
        {
            _bodyRendererHandler.DisableSpriteRenderer();
            _playerEngineParticleEffectsStopper.EngineParticleSystemsTurnOff();
        }

        public void OnCompleteDieCoroutine()
        {
            _bodyRendererHandler.EnableSpriteRenderer();
        }
    }
}