using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Microgame : MonoBehaviour
{
    protected bool result;
    protected string objectiveName;
    float objectiveTime, playTime;

    // With all virtual methods make sure when overriding to call base.MethodName(); at the start

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
        EventManager.current.DisplayObjective(objectiveName, objectiveTime);
    }

    protected virtual void PlayMicrogame()
    {
        EventManager.current.MicrogamePlay(playTime);
    }

    protected virtual void StopMicrogame()
    {
        EventManager.current.MicrogameStop(result);
    }
}