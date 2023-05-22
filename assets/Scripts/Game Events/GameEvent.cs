using System.Collections.Generic;
using UnityEngine;

namespace Game_Events
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject, IGameEvent
    {
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<IGameEventListener> _eventListeners =
            new List<IGameEventListener>();

        public void Raise()
        {
            for (int i = _eventListeners.Count - 1; i >= 0; i--)
                _eventListeners[i].OnEventRaised(this);
        }

        public void RegisterListener(IGameEventListener listener)
        {
            if (!_eventListeners.Contains(listener))
                _eventListeners.Add(listener);
        }

        public void UnregisterListener(IGameEventListener listener)
        {
            if (_eventListeners.Contains(listener))
                _eventListeners.Remove(listener);
        }
    }
}