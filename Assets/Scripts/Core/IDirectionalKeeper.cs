using UnityEngine;

namespace TheSicker.Core
{ 
    public interface IDirectionalKeeper
    {
        Vector3 LastEulerDirection { get; }

        void StoreDirectionEulerVector(Vector3 eulerDirection);
    }
}
