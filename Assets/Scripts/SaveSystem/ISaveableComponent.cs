namespace TheSicker.SaveSystem
{
    public interface ISaveableComponent
    {
        object CaptureState();

        void RestoreState(object state);
    }
}
