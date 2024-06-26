using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public abstract class Microgame : MonoBehaviour
{
    protected bool result = false;

    [SerializeField] protected string objectiveName = "";
    [SerializeField] protected float objectiveTime = 1;
    [SerializeField] protected float playTime = 10;

    // With all virtual methods make sure when overriding to call base.MethodName(); at the start

    // MAKE SURE TO OVERRIDE
    protected virtual void Start()
    {
        EventManager.current.onTimerStop += StopMicrogame;
        EventManager.current.onPopupFinished += PlayMicrogame;
    }

    protected void OnDestroy()
    {
        EventManager.current.onTimerStop -= StopMicrogame;
        EventManager.current.onPopupFinished -= PlayMicrogame;
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
        Debug.Log("StartMicrogame");
        EventManager.current.PopUp(objectiveTime);
    }
   
    // MAKE SURE TO OVERRIDE
    protected virtual void PlayMicrogame() // Game Begin
    {
        Debug.Log("PlayMicrogame");

        result = false;

        EventManager.current.MicrogamePlay(playTime);

        InputManager.current.SetControlsActive(true);
    }

    // MAKE SURE TO OVERRIDE
    protected virtual void StopMicrogame() // Game Stop
    {
        Debug.Log("StopMicrogame");

        EventManager.current.MicrogameStop(result);

        InputManager.current.SetControlsActive(false);

        SceneLoader.current.UnloadScene(gameObject.scene);
    }
}