using UnityEngine;

namespace TheSicker.Core
{
    public class SoundEffectHandler : MonoBehaviour
    {
        [SerializeField] AudioClip sfxAudio = null;
        [SerializeField] float sfxAudioVolume = 0.5f;

        public void StartSfx()
        {
            if (!sfxAudio) return;

            AudioSource.PlayClipAtPoint(sfxAudio, Camera.main.transform.position, sfxAudioVolume);
        }
    }
}
