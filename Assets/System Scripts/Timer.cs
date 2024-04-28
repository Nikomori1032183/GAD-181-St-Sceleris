using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float time = 0;

    private void Start()
    {
        EventManager.current.onMicrogamePlay += TimerStart;
    }

    private void TimerStart(float seconds)
    {
        time = seconds;
        UpdateVisual();

        Debug.Log("TimerStart");

        StopCoroutine(TimerCoroutine(seconds));
        StartCoroutine(TimerCoroutine(seconds));
    }

    private IEnumerator TimerCoroutine(float seconds)
    {
        for (; time > 0; time--)
        {
            yield return new WaitForSeconds(1);
            UpdateVisual();
        }

        TimerStop();
    }

    private void UpdateVisual()
    {
        //
        Debug.Log("Time: " + time);
    }

    private void TimerStop()
    {
        EventManager.current.TimerStop();
    }
}