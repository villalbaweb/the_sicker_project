namespace TheSicker.SaveSystem
{
    public interface ISaveableComponent
    {
        object CaptureState(StateType stateType);

        void RestoreState(StateType stateType, object state);
    }
}
