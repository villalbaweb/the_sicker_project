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
        }

        private void OnEnable() 
        {
            _playerMover.OnStartMovement += OnStartMovementEvent; 
            _playerMover.OnStopMovement += OnStopMovementEvent;
            _playerMover.OnTurboSpeedStart += OnTurboSpeedStartEvent;
        }

        private void OnDisable() 
        {
            _playerMover.OnStartMovement -= OnStartMovementEvent;  
            _playerMover.OnStopMovement -= OnStopMovementEvent;
            _playerMover.OnTurboSpeedStart -= OnTurboSpeedStartEvent;
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

            OnTurboSpeedStopEvent();
        }

        private void OnTurboSpeedStartEvent()
        {
            print("Starting turbo");
            if(!speedEngineParticleSystem.isPlaying)
            {
                speedEngineParticleSystem.Play();
                TrailParticleSystemStart(true);
            }
        }

        private void OnTurboSpeedStopEvent()
        {
            print("Stoping turbo");
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