using UnityEngine;

namespace TheSicker.Core
{
    public interface IDirectionalDamageSpawner
    {
        void DirectionalDamageVfxSpawn(Vector2 position, Vector3 eulerAngles);
    }
}
