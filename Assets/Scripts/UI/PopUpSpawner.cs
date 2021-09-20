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
            GameObject popUpGameObject = _objectPooler.SpawnFromPool(popUpObjectPoolId.ToString(), transform.position, Quaternion.identity);
            PopUpController popUpController = popUpGameObject?.GetComponent<PopUpController>();
            popUpController?.Setup(popupMessage);
        }
    }
}