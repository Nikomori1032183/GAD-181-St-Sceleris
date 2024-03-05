using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    // Microgame Events

    public event Action onDisplayObjective;
    public void DisplayObjective()
    {
        if (onDisplayObjective != null)
        {
            onDisplayObjective();
        }
    }

    public event Action onMicrogamePlay;
    public void MicrogamePlay()
    {
        if (onMicrogamePlay != null)
        {
            onMicrogamePlay();
        }
    }

    public event Action onMicrogameStop;
    public void MicrogameStop()
    {
        if (onMicrogameStop != null)
        {
            onMicrogameStop();
        }
    }
}
