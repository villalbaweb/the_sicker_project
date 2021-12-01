using System.Collections;
using System.Collections.Generic;
using TheSicker.Game;
using UnityEngine;

namespace TheSicker.Core
{
    public class SpecialEffectsHandler : MonoBehaviour
    {
        // config
        [Header("Sound Effects to Play")]
        [SerializeField] List<AudioClip> soundFx = null;

        [Header("Visual Effects to Play")]
        [SerializeField] ObjectPoolIds[] visualEffectsToSpawn;

        // cache
        ObjectPooler _objectPooler;
        GameSoundController _gameSoundController;

        private void Awake()
        {
            _objectPooler = FindObjectOfType<ObjectPooler>();
            _gameSoundController = FindObjectOfType<GameSoundController>();
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
            foreach(ObjectPoolIds objectPoolId in visualEffectsToSpawn)
            {
                _objectPooler.SpawnFromPool(objectPoolId.ToString(), transform.position, Quaternion.identity);
            }

            yield return null;
        }

        IEnumerator PositionedVisualFxRunCoroutine(Vector3 playPosition)
        {
            foreach(ObjectPoolIds objectPoolId in visualEffectsToSpawn)
            {
                _objectPooler.SpawnFromPool(objectPoolId.ToString(), playPosition, Quaternion.identity);
            }

            yield return null;
        }

        IEnumerator SoundFxRunCoroutine()
        {
            foreach(AudioClip clip in soundFx)
            {
                _gameSoundController?.PlayClipAtCamera(clip);
            }

            yield return null;
        }
    }
}