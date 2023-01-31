using System.Linq;
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


        #region Private Methods

        private void Awake()
        {
            _musicAudioSource = GetComponent<AudioSource>();

            OnIsMusicMuteChange();
        }

        private void OnEnable()
        {
            if (!gameMusic) return;

            gameMusic.OnIsMusicMuteChange += OnIsMusicMuteChange;
        }

        private void OnDisable()
        {
            if (!gameMusic) return;

            gameMusic.OnIsMusicMuteChange -= OnIsMusicMuteChange;
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

        private void OnIsMusicMuteChange()
        {
            _musicAudioSource.mute = gameMusic.IsMusicMute;
        }


        private AudioClip RandomlySelectPlayMusic()
        {
            return gameMusic.GamePlayMusic
            .OrderBy(x => System.Guid.NewGuid())
            .Take(1)
            .FirstOrDefault();
        }

        #endregion


        #region Public Methods

        public void PlayRegularGameMusic()
        {
            if (!_musicAudioSource) return;

            _musicAudioSource.Stop();
            _musicAudioSource.clip = RandomlySelectPlayMusic();
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

        #endregion

    }

    public enum MusicType
    {
        SplashScreen,
        PlayGame,
        GameOver
    }
}
