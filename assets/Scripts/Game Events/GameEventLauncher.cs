using UnityEngine;

namespace Game_Events
{
    public class GameEventLauncher : MonoBehaviour
    {
        public GameEvent gameEvent;

        public void LaunchEvent()
        {
            gameEvent.Raise();
        }
    }
}
