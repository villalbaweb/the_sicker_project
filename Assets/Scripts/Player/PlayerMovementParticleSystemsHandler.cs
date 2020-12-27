using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerMovementParticleSystemsHandler : MonoBehaviour
    {
        // config
        [Header("VFX")]
        [SerializeField] ParticleSystem engineParticleSystem = null;
        [SerializeField] ParticleSystem speedEngineParticleSystem = null;
        [SerializeField] TrailRenderer[] trailRenderers = null;

        // cache
        PlayerMover _playerMover;

        private void Awake() 
        {
            _playerMover = GetComponent<PlayerMover>();

            engineParticleSystem.Stop();
            speedEngineParticleSystem.Stop();
            TrailRenderersStart(false);
        }

        private void OnEnable() 
        {
            _playerMover.OnStartMovement += OnStartMovementEvent; 
            _playerMover.OnStopMovement += OnStopMovementEvent;
            _playerMover.OnTurboSpeedStart += OnTurboSpeedStartEvent;
            _playerMover.OnTurboSpeedStop += OnTurboSpeedStopEvent;
        }

        private void OnDisable() 
        {
            _playerMover.OnStartMovement -= OnStartMovementEvent;  
            _playerMover.OnStopMovement -= OnStopMovementEvent;
            _playerMover.OnTurboSpeedStart -= OnTurboSpeedStartEvent;
            _playerMover.OnTurboSpeedStop -= OnTurboSpeedStopEvent;
        }

        private void OnStartMovementEvent()
        {
            if (engineParticleSystem && !engineParticleSystem.isPlaying)
            {
                engineParticleSystem.Play();
            }
        }

        private void OnStopMovementEvent()
        {
            if (engineParticleSystem && !engineParticleSystem.isStopped)
            {
                engineParticleSystem.Stop();
            }

            if (speedEngineParticleSystem && !speedEngineParticleSystem.isStopped)
            {
                speedEngineParticleSystem.Stop();
                TrailRenderersStart(false);
            }
        }

        private void OnTurboSpeedStartEvent()
        {
            if(speedEngineParticleSystem && !speedEngineParticleSystem.isPlaying)
            {
                speedEngineParticleSystem.Play();
                TrailRenderersStart(true);
            }
        }

        private void OnTurboSpeedStopEvent()
        {
            if (speedEngineParticleSystem && !speedEngineParticleSystem.isStopped)
            {
                speedEngineParticleSystem.Stop();
                TrailRenderersStart(false);
            }
        }

        private void TrailRenderersStart(bool start)
        {
            if (start)
            {
                foreach (TrailRenderer trail in trailRenderers)
                {
                    trail.emitting = true;
                }
            }
            else
            {
                foreach (TrailRenderer trail in trailRenderers)
                {
                    trail.emitting = false;
                }
            }
        }
    }
}