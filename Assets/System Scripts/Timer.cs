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
        text = GetComponent <TMP_Text>();
    }

    private void TimerStart(float seconds)
    {
        time = seconds;
        UpdateVisual(time.ToString());

        Debug.Log("TimerStart");

        StopCoroutine(TimerCoroutine(seconds));
        StartCoroutine(TimerCoroutine(seconds));
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
        text.text = timeLeft;
        //Debug.Log("Time: " + time);
    }

    private void TimerStop()
    {
        EventManager.current.TimerStop();
    }
}