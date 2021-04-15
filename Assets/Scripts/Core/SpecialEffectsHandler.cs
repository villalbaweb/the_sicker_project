using System.Collections.Generic;
using UnityEngine;

namespace TheSicker.Core
{
    public class SpecialEffectsHandler : MonoBehaviour
    {
        // config
        [Header("Sound Effects to Play")]
        [SerializeField] List<AudioClip> soundFx = null;
        [SerializeField] float sfxAudioVolume = 0.5f;

        [Header("Visual Effects to Play")]
        [SerializeField] GameObject visualFxPrefab = null;

        public void PlaySpecialEffects()
        {
            print("How to play all the events async ???");
        }
    }
}