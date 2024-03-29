using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public abstract class Microgame : MonoBehaviour
{
    protected bool result = false;
    protected bool playing;
    [SerializeField] protected string objectiveName = "";
    [SerializeField] protected float objectiveTime = 1;
    [SerializeField] protected float playTime = 10;

    // With all virtual methods make sure when overriding to call base.MethodName(); at the start

    protected virtual void Start()
    {
        EventManager.current.onTimerStop += PlayMicrogame;
        EventManager.current.onTimerStop += StopMicrogame;
    }

    // I think that hese actually arent needed anymore after building out some of the systems but il leave it here just in case
    //private bool GetResult()
    //{
    //    return result;
    //}

    //private void SetResult(bool result)
    //{
    //    result = this.result;
    //}

    public void StartMicrogame()
    {
        StartCoroutine(DisplayObjective());
    }

    protected IEnumerator DisplayObjective()
    {
        // Tell UI Manager to display Objective Text
        EventManager.current.DisplayObjective();

        // Wait Time
        yield return new WaitForSeconds(objectiveTime);

        // Tell UI Manager to stop displaying Objective Text
        EventManager.current.HideObjective();

        // Play Microgame
        PlayMicrogame();
    }

    protected virtual void PlayMicrogame() // Game Begin
    {
        EventManager.current.MicrogamePlay(playTime);
        playing = true;
    }

    protected virtual void StopMicrogame() // Game Stop
    {
        EventManager.current.MicrogameStop(result);
        playing = false;
    }
}