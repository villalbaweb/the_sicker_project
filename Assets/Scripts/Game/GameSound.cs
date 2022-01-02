using UnityEngine;

namespace TheSicker.Game
{
    [CreateAssetMenu(fileName = "GameSound", menuName = "Game Configuration/New GameSound", order = 0)]
    public class GameSound : ScriptableObject
    {
        // config
        [SerializeField] float audioVolume = 1f;
        [SerializeField] bool isSoundMute = false;

        // properties
        public float AudioVolume => audioVolume;

        public bool IsSoundMute
        {
            get => isSoundMute;
            set => isSoundMute = value;
        }

    }
}