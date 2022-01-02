using UnityEngine;

namespace TheSicker.Game
{
    public class GameMusicController : MonoBehaviour
    {
        // config params
        [SerializeField] GameMusic gameMusic = null;
        [SerializeField] MusicType musicType = MusicType.PlayGame;

        // cache
        AudioSource _musicAudioSource;

        private void Awake()
        {
            _musicAudioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            switch (musicType)
            {
                case MusicType.PlayGame: PlayRegularGameMusic();
                    break;
                case MusicType.GameOver: PlayGameOverMusic();
                    break;
                case MusicType.SplashScreen: PlaySplashScreenMusic();
                    break;
            }
        }

        public void PlayRegularGameMusic()
        {
            if (!_musicAudioSource) return;

            _musicAudioSource.Stop();
            _musicAudioSource.clip = gameMusic.GamePlayMusic;
            _musicAudioSource.volume = gameMusic.GameMusicVolumenLevel;
            _musicAudioSource.Play();
        }

        public void PlayGameOverMusic()
        {
            if (!_musicAudioSource) return;

            _musicAudioSource.Stop();
            _musicAudioSource.clip = gameMusic.GameOverMusic;
            _musicAudioSource.volume = gameMusic.GameMusicVolumenLevel;
            _musicAudioSource.Play();
        }

        public void PlaySplashScreenMusic()
        {
            if (!_musicAudioSource) return;

            _musicAudioSource.Stop();
            _musicAudioSource.clip = gameMusic.SplashScreenMusic;
            _musicAudioSource.volume = gameMusic.GameMusicVolumenLevel;
            _musicAudioSource.Play();
        }
    }

    public enum MusicType
    {
        SplashScreen,
        PlayGame,
        GameOver
    }
}
