using UnityEngine;

namespace TheSicker.Combat
{
    public class WeaponPickupSoundEffectHandler : MonoBehaviour
    {
        // config
        [SerializeField] AudioClip sfxAudio = null;
        [SerializeField] float sfxAudioVolume = 0.5f;

        public void PickupSoundEffectPlay()
        {
            if (!sfxAudio) return;

            AudioSource.PlayClipAtPoint(sfxAudio, Camera.main.transform.position, sfxAudioVolume);
        }
    }
}
