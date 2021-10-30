namespace TheSicker.SaveSystem
{
    public interface ISaveableGameObject
    {
        object CaptureState(StateType stateType);

        string GetUniqueIdentifier();

        void RestoreState(StateType stateType, object state);
    }
}
