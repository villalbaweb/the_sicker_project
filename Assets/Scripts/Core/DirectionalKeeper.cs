using UnityEngine;

namespace TheSicker.Core
{
    public class DirectionalKeeper : MonoBehaviour, IDirectionalKeeper
    {
        // state
        Vector3 lastEulerDirection;

        #region Interface Implementation 
        
        public Vector3 LastEulerDirection => lastEulerDirection;

        public void StoreDirectionEulerVector(Vector3 eulerDirection)
        {
            lastEulerDirection = eulerDirection;
        }

        #endregion
    }
}
