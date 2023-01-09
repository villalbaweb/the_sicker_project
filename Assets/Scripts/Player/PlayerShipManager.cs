using System.Linq;
using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerShipManager : MonoBehaviour
    {
        // config
        [SerializeField] PlayerShips playerShips;
        [SerializeField] Vector3 shipScale;
        [SerializeField] Vector3 shipPosition;
        [SerializeField] Vector3 shipRotation;

        private void Awake()
        {
            Ships selectedShip = RandomlySelectShip();

            print($"{selectedShip.Name}");

            MiniMapIconSetup(selectedShip);
            ShipBodySetup(selectedShip);
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

        private void ShipBodySetup(Ships generatedShip)
        {
            GameObject shipBodyGameObject = Instantiate(generatedShip.Body, transform);
            Transform shipBodyTransform = shipBodyGameObject.transform;
            shipBodyTransform.localPosition = new Vector3(shipPosition.x, shipPosition.y, shipPosition.z);
            shipBodyTransform.localScale = new Vector3(shipScale.x, shipScale.y, shipScale.z);
            shipBodyTransform.localRotation = Quaternion.Euler(shipRotation.x, shipRotation.y, shipRotation.z);
        }
    }
}
