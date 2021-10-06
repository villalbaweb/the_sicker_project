namespace TheSicker.SaveSystem
{
    public interface ISaveableGameObject
    {
        object CaptureState();

        string GetUniqueIdentifier();

        void RestoreState(object state);
    }
}
