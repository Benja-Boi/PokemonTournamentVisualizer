using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game_Events
{
    public class MultiGameEventListener : MonoBehaviour, IGameEventListener
    {
        [Tooltip("ToDo.")]
        public List<InteractionMap> interactionMaps;
        private Dictionary<IGameEvent, InteractionMap> _mapDict;

        private void Awake()
        {
            _mapDict = new Dictionary<IGameEvent, InteractionMap>();
        }


        private void OnEnable()
        {
            foreach (InteractionMap interactionMap in interactionMaps)
            {
                interactionMap.gameEvent.RegisterListener(this);
                _mapDict.Add(interactionMap.gameEvent, interactionMap);
            }
        }

        private void OnDisable()
        {
            foreach (InteractionMap interactionMap in interactionMaps)
            {
                interactionMap.gameEvent.UnregisterListener(this);
                _mapDict.Remove(interactionMap.gameEvent);
            }
        }

        public void OnEventRaised(IGameEvent gameEvent)
        {
            _mapDict[gameEvent].responses.Invoke();
        }
        
        public void OnEventRaised(IGameEvent gameEvent, int value)
        {
            // adapt to int!
            _mapDict[gameEvent].responses.Invoke();
        }
        
        public void OnEventRaised(IGameEvent gameEvent, float value)
        {
            // adapt to float!
            _mapDict[gameEvent].responses.Invoke();
        }
    }

    [Serializable]
    public class InteractionMap
    {
        public GameEvent gameEvent;
        public UnityEvent responses;
    }
}