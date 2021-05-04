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

        // cache
        TemporaryGameObjectsHandler _temporaryGameObjectsHandler;

        private void Awake()
        {
            _temporaryGameObjectsHandler = FindObjectOfType<TemporaryGameObjectsHandler>();
        }

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
                GameObject obj = Instantiate(go, transform.position, Quaternion.identity);
                obj.transform.parent = _temporaryGameObjectsHandler.TemporaryObjectParentTransform;
            }

            yield return null;
        }

        IEnumerator PositionedVisualFxRunCoroutine(Vector3 playPosition)
        {
            foreach (GameObject go in visualEffectPrefabs)
            {
                GameObject obj = Instantiate(go, playPosition, Quaternion.identity);
                obj.transform.parent = _temporaryGameObjectsHandler.TemporaryObjectParentTransform;
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