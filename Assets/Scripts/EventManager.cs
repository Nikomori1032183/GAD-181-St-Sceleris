using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake()
    {
        current = this;
    }

    // Microgame Events
    public event Action<string, float> onDisplayObjective;
    public void DisplayObjective(string objectiveName, float objectiveTime)
    {
        if (onDisplayObjective != null)
        {
            onDisplayObjective(objectiveName, objectiveTime);
        }
    }

    public event Action<float> onMicrogamePlay;
    public void MicrogamePlay(float playTime)
    {
        if (onMicrogamePlay != null)
        {
            onMicrogamePlay(playTime);
        }
    }

    public event Action<bool> onMicrogameStop;
    public void MicrogameStop(bool result)
    {
        if (onMicrogameStop != null)
        {
            onMicrogameStop(result);
        }
    }
}