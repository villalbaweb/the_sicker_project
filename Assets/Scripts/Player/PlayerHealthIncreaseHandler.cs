using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheSicker.Core;

namespace TheSicker.Player
{
    public class PlayerHealthIncreaseHandler : MonoBehaviour
    {
        // config
        [SerializeField] int increaseHealthPoints = 50;

        public void IncreaseHealth(GameObject increaseHealthTo)
        {
            Health _playerHealth = increaseHealthTo.GetComponent<Health>();
            _playerHealth.IncreaseHealth(increaseHealthPoints);
        }
    }
}
