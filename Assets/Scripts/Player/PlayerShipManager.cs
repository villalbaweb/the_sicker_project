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
            Ships selectedShip = RandomlySelectShip();

            print($"{selectedShip.Name}");

            MiniMapIconSetup(selectedShip);
        }

        private Ships RandomlySelectShip()
        {
            return playerShips.Ships
            .OrderBy(x => System.Guid.NewGuid())
            .Take(1)
            .FirstOrDefault();
        }

        private void MiniMapIconSetup(Ships generatedShip)
        {
            SpriteRenderer spriteRenderer = transform.Find("Minimap Icon")?.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = generatedShip.MinimapIcon;
            }
        }
    }
}
