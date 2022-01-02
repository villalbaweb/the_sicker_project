using UnityEngine;

namespace TheSicker.Game
{
    public class GameSoundController : MonoBehaviour
    {
        // config params
        [SerializeField] GameSound gameSound = null;

        public void SwitchSoundMute(bool isMuted)
        {
            gameSound.IsSoundMute = isMuted;
        }

        public void PlayClipAtCamera(AudioClip clip, float specificVolume = -1)
        {
            if (!clip || gameSound.IsSoundMute) return;

            float playSoundVolume = specificVolume == -1 ? gameSound.AudioVolume : specificVolume;

            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, playSoundVolume);
        }
    }
}
