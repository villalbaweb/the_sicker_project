using UnityEngine;

namespace TheSicker.Core
{
    public class DirectionalDamageSpawner : MonoBehaviour, IDirectionalDamageSpawner
    {
        public void DirectionalDamageVfxSpawn(Vector2 position)
        {
            print($"DirectionalDamageVfxSpawn {position}");
        }
    }
}
