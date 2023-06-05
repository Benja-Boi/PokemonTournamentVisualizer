using System.Collections;
using System.Collections.Generic;
using Game_Events;
using UnityEngine;

public interface IGameEventListener
{
    void OnEventRaised(GameEvent gameEvent);
}