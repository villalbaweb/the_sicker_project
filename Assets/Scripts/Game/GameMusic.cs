using UnityEngine;

namespace TheSicker.Game
{
    [CreateAssetMenu(fileName = "GameMusic", menuName = "Game Configuration/New GameMusic", order = 0)]
    public class GameMusic : ScriptableObject
    {
        // config props
        [SerializeField] AudioClip gamePlayMusic;
        [SerializeField] AudioClip gameOverMusic;
        [SerializeField] AudioClip splashScreenMusic;
        [SerializeField] [Range(0, 1)] float gameMusicVolumenLevel = 1f;

        // properties
        public AudioClip GamePlayMusic => gamePlayMusic;
        public AudioClip GameOverMusic => gameOverMusic;
        public AudioClip SplashScreenMusic => splashScreenMusic;
        public float GameMusicVolumenLevel => gameMusicVolumenLevel;
    }
}
