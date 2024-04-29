using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float time = 0;

    TMP_Text text;

    private void Start()
    {
        EventManager.current.onMicrogamePlay += TimerStart;
        EventManager.current.onMicrogameStop += TimerStop;
        text = GetComponent <TMP_Text>();
    }

    private void TimerStart(float seconds)
    {
        //Debug.Log("TimerStart");

        time = seconds;
        UpdateVisual(time.ToString());

        StartCoroutine(TimerCoroutine(seconds));
    }

    private void TimerStop(bool result)
    {
        StopCoroutine(TimerCoroutine(0));
        time = 0;
        UpdateVisual("");
    }

    private IEnumerator TimerCoroutine(float seconds)
    {
        for (; time > 0; time--)
        {
            UpdateVisual(time.ToString());
            yield return new WaitForSeconds(1);
        }

        UpdateVisual(time.ToString());

        TimerStop();
    }

    private void UpdateVisual(string timeLeft)
    {
        if (timeLeft.Contains("-"))
        {
            text.text = " ";
        }
        else
        {
            text.text = timeLeft;
        }
        //Debug.Log("Time: " + time);
    }

    private void TimerStop()
    {
        EventManager.current.TimerStop();
    }
}