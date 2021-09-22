using TheSicker.Core;
using UnityEngine;

namespace TheSicker.UI
{
    public class PopUpSpawner : MonoBehaviour
    {
        // config
        [SerializeField] string popupMessage;
        [SerializeField] ObjectPoolIds popUpObjectPoolId;

        // cache
        ObjectPooler _objectPooler;

        private void Awake()
        {
            _objectPooler = FindObjectOfType<ObjectPooler>();
        }

        public void PopUpSpawn()
        {
            Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, 0);
            GameObject popUpGameObject = _objectPooler.SpawnFromPool(popUpObjectPoolId.ToString(), spawnPos, Quaternion.identity);
            PopUpController popUpController = popUpGameObject?.GetComponent<PopUpController>();
            popUpController?.Setup(popupMessage);
        }
    }
}