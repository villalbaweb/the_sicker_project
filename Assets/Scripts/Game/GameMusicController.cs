using UnityEngine;

namespace TheSicker.Game
{
    public class GameMusicController : MonoBehaviour
    {
        // config params
        [SerializeField] GameMusic gameMusic = null;

        // cache
        AudioSource _musicAudioSource;

        private void Awake()
        {
            _musicAudioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            PlayRegularGameMusic();
        }

        public void PlayRegularGameMusic()
        {
            if (!_musicAudioSource) return;

            _musicAudioSource.Stop();
            _musicAudioSource.clip = gameMusic.GamePlayMusic;
            _musicAudioSource.volume = gameMusic.GameMusicVolumenLevel;
            _musicAudioSource.Play();
        }
    }
}
