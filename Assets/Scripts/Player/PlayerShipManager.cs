using System.Linq;
using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerShipManager : MonoBehaviour
    {
        // config
        [SerializeField] PlayerShips playerShips;

        private void Awake()
        {
            Ships selectedShip = RandmlySelectShip();

            print($"{selectedShip.Name}");
        }

        private Ships RandmlySelectShip()
        {
            return playerShips.Ships
            .OrderBy(x => System.Guid.NewGuid())
            .Take(1)
            .FirstOrDefault();
        }
    }
}
