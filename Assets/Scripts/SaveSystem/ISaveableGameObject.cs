using System.Collections.Generic;

namespace TheSicker.SaveSystem
{
    public interface ISaveableGameObject
    {
        object CaptureState(StateType stateType, Dictionary<string, object> saveableGameObjectCurrentState);

        string GetUniqueIdentifier();

        void RestoreState(StateType stateType, object state);
    }
}
