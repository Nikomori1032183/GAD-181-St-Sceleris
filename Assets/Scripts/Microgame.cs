using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Microgame : MonoBehaviour
{
    protected bool result;
    protected string objectiveName;
    float objectiveTime, playTime;

    protected virtual void Start()
    {
        
    }

    public bool GetResult()
    {
        return result;
    }

    public void SetResult(bool result)
    {
        result = this.result;
    }

    protected virtual void DisplayObjective()
    {
        // Tells UI Manager To Display 
        //EventManager.current
    }

    protected virtual void PlayMicrogame()
    {
        // Tell Event Manager
    }

    protected virtual void StopMicrogame()
    {
        // Tell Event Manager
    }
}
