using TheSicker.Game;
using UnityEngine;

namespace TheSicker.Combat
{
    public class WeaponPickupSoundEffectHandler : MonoBehaviour
    {
        // config
        [SerializeField] AudioClip sfxAudio = null;

        // cache
        GameSoundController _gameSoundController;

        private void Awake()
        {
            _gameSoundController = FindObjectOfType<GameSoundController>();
        }

        public void PickupSoundEffectPlay()
        {
            if (!sfxAudio) return;

            _gameSoundController?.PlayClipAtCamera(sfxAudio);
        }
    }
}
