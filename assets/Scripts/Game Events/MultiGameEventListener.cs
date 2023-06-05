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
        private Dictionary<GameEvent, InteractionMap> _mapDict;

        private void Awake()
        {
            _mapDict = new Dictionary<GameEvent, InteractionMap>();
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

        public void OnEventRaised(GameEvent gameEvent)
        {
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