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

        #region Public Methods

        public void PopUpSpawn()
        {
            PopUpController popUpController = GetPopupControllerFromPool();
            popUpController?.Setup(popupMessage);
        }

        public void PopUpSpawn(string customPopupMessage)
        {
            PopUpController popUpController = GetPopupControllerFromPool();
            popUpController?.Setup(customPopupMessage);
        }

        #endregion

        #region Private Methods

        private PopUpController GetPopupControllerFromPool()
        {
            Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, 0);
            GameObject popUpGameObject = _objectPooler.SpawnFromPool(popUpObjectPoolId.ToString(), spawnPos, Quaternion.identity);
            PopUpController popUpController = popUpGameObject?.GetComponent<PopUpController>();
            return popUpController;
        }

        #endregion
    }
}