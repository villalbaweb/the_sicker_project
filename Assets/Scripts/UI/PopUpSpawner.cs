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
        DirectionalKeeper _directionalKeeper;

        private void Awake()
        {
            _objectPooler = FindObjectOfType<ObjectPooler>();
            _directionalKeeper = GetComponent<DirectionalKeeper>();
        }

        #region Public Methods

        public void PopUpSpawn()
        {
            PopUpController popUpController = GetPopupControllerFromPool();
            popUpController?.Setup(popupMessage, _directionalKeeper.LastEulerDirection);
        }

        public void PopUpSpawn(string customPopupMessage)
        {
            PopUpController popUpController = GetPopupControllerFromPool();
            popUpController?.Setup(customPopupMessage, _directionalKeeper.LastEulerDirection);
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