using System.Collections;
using System.Collections.Generic;
using Game_Events;
using UnityEngine;
using UnityEngine.Serialization;

public class GameEventLauncher : MonoBehaviour
{
    public GameEvent gameEvent;

    public void LaunchEvent()
    {
        gameEvent.Raise();
    }
}
