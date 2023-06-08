using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Game_Events
{
    public class GameEventListener : MonoBehaviour, IGameEventListener
    {
        [Tooltip("Event to register with.")]
        public GameEvent @event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent responses;

        [Tooltip("Response to invoke when Event is raised with int param.")]
        public IntEvent intResponses;

        [Tooltip("Response to invoke when Event is raised with float param.")]
        public FloatEvent floatResponses;

        private void OnEnable()
        {
            @event.RegisterListener(this);
        }

        private void OnDisable()
        {
            @event.UnregisterListener(this);
        }

        public void OnEventRaised(IGameEvent gameEvent)
        {
            responses.Invoke();
        }

        public void OnEventRaised(IGameEvent gameEvent, int value)
        {
            intResponses.Invoke(value);
        }
        
        public void OnEventRaised(IGameEvent gameEvent, float value)
        {
            floatResponses.Invoke(value);
        }
    }
}