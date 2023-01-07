using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheSicker.Player
{
    [CreateAssetMenu(fileName = "PlayerShips", menuName = "Player/New PlayerShips", order = 0)]
    public class PlayerShips : ScriptableObject
    {
        // config
        [SerializeField] List<Ships> ships;

        public List<Ships> Ships => ships;
    }

    [Serializable]
    public class Ships
    {
        public string Name;
        public GameObject Body;
        public Sprite MinimapIcon;
    }
}
