using TheSicker.SaveSystem;
using UnityEngine;

namespace TheSicker.Player
{
    public class PlayerMaxXpHandler : MonoBehaviour, ISaveableComponent
    {
        // config
        [SerializeField] int maxXpLevel = 10;

        public object CaptureState(StateType stateType)
        {
            if (stateType != StateType.MaxXp) return null;

            return maxXpLevel;
        }

        public void RestoreState(StateType stateType, object state)
        {
            if (stateType != StateType.MaxXp) return;

            maxXpLevel = (int)state;
        }
    }
}
