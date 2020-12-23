using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerMovementParticleSystemsHandler : MonoBehaviour
    {
        // config
        [Header("VFX")]
        [SerializeField] ParticleSystem engineParticleSystem = null;
        [SerializeField] ParticleSystem speedEngineParticleSystem = null;
        [SerializeField] ParticleSystem[] trailParticleSystem = null;

        // cache
        PlayerMover _playerMover;

        private void Awake() 
        {
            _playerMover = GetComponent<PlayerMover>();

            engineParticleSystem.Stop();
            speedEngineParticleSystem.Stop();
            TrailParticleSystemStart(false);
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
            if (!engineParticleSystem.isPlaying)
            {
                engineParticleSystem.Play();
            }
        }

        private void OnStopMovementEvent()
        {
            if (!engineParticleSystem.isStopped)
            {
                engineParticleSystem.Stop();
            }

            if (!speedEngineParticleSystem.isStopped)
            {
                speedEngineParticleSystem.Stop();
                TrailParticleSystemStart(false);
            }
        }

        private void OnTurboSpeedStartEvent()
        {
            if(!speedEngineParticleSystem.isPlaying)
            {
                speedEngineParticleSystem.Play();
                TrailParticleSystemStart(true);
            }
        }

        private void OnTurboSpeedStopEvent()
        {
            if (!speedEngineParticleSystem.isStopped)
            {
                speedEngineParticleSystem.Stop();
                TrailParticleSystemStart(false);
            }
        }

        private void TrailParticleSystemStart(bool start)
        {
            if (start)
            {
                foreach (ParticleSystem trail in trailParticleSystem)
                {
                    trail.Play();
                }
            }
            else
            {
                foreach (ParticleSystem trail in trailParticleSystem)
                {
                    trail.Stop();
                }
            }
        }
    }
}