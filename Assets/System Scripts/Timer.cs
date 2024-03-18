using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    int time = 0;

    private void Start()
    {
        //EventManager
    }

    private IEnumerator TimerStart(int seconds)
    {
        time = seconds;
        UpdateVisual();

        for (int i = 0; i > 0; i--)
        {
            yield return new WaitForSeconds(1);
            UpdateVisual();
        }

        TimerStop();
    }

    private void UpdateVisual()
    {
        //
    }

    private void TimerStop()
    {
        EventManager.current.TimerStop();
    }
}