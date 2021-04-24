using System.Collections;
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
        [SerializeField] GameObject[] visualEffectPrefabs = null;

        public void PlaySpecialEffects()
        {
            StartCoroutine(VisualFxRunCoroutine());
            StartCoroutine(SoundFxRunCoroutine());
        }

        public void PlaySpecialEffectsOnPosition(Vector3 playPosition)
        {
            StartCoroutine(PositionedVisualFxRunCoroutine(playPosition));
            StartCoroutine(SoundFxRunCoroutine());
        }

        IEnumerator VisualFxRunCoroutine()
        {
            foreach(GameObject go in visualEffectPrefabs)
            {
                Instantiate(go, transform.position, Quaternion.identity);
            }

            yield return null;
        }

        IEnumerator PositionedVisualFxRunCoroutine(Vector3 playPosition)
        {
            foreach (GameObject go in visualEffectPrefabs)
            {
                Instantiate(go, playPosition, Quaternion.identity);
            }

            yield return null;
        }

        IEnumerator SoundFxRunCoroutine()
        {
            foreach(AudioClip clip in soundFx)
            {
                AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, sfxAudioVolume);
            }

            yield return null;
        }
    }
}