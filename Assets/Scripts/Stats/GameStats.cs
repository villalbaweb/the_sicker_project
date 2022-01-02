using UnityEngine;

namespace TheSicker.Stats
{
    [CreateAssetMenu(fileName = "GameStats", menuName = "Stats/New GameStats", order = 0)]
    public class GameStats : ScriptableObject
    {
        // config
        [SerializeField] private float playerMaxXp;
        [SerializeField] private float playerXp;

        // properties
        public float PlayerMaxXp
        { 
            get => playerMaxXp; 
            set => playerMaxXp = value;
        }

        public float PlayerXp
        {
            get => playerXp;
            set => playerXp = value;
        }
    }
}
