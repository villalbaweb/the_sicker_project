using TheSicker.Game;
using UnityEngine;

namespace TheSicker.Core
{
    public class SoundEffectHandler : MonoBehaviour
    {
        [SerializeField] AudioClip sfxAudio = null;

        // cache
        GameSoundController _gameSoundController;

        private void Awake()
        {
            _gameSoundController = FindObjectOfType<GameSoundController>();
        }

        public void StartSfx()
        {
            if (!sfxAudio) return;

            _gameSoundController?.PlayClipAtCamera(sfxAudio);
        }
    }
}
