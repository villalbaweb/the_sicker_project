using UnityEngine;

namespace TheSicker.Core
{
    public class DirectionalDamageSpawner : MonoBehaviour, IDirectionalDamageSpawner
    {
        // config
        [SerializeField] ObjectPoolIds popUpObjectPoolId;

        // cache
        ObjectPooler _objectPooler;

        private void Awake()
        {
            _objectPooler = FindObjectOfType<ObjectPooler>();
        }

        #region Interface Implementation 

        public void DirectionalDamageVfxSpawn(Vector2 position, Vector3 eulerAngles)
        {
            GameObject directionalDamageVfxObject = _objectPooler.SpawnFromPool(popUpObjectPoolId.ToString(), position, Quaternion.identity);
            directionalDamageVfxObject.transform.eulerAngles = eulerAngles;
        }

        #endregion
    }
}
