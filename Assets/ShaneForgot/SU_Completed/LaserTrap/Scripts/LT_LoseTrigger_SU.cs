using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LT_LoseTrigger_SU : MonoBehaviour
{
    public GameObject laser;
    LT_Main mainScript;

    void Start()
    {
        laser = this.gameObject;
        mainScript = FindAnyObjectByType<LT_Main>();
    }

    private void OnTriggerEnter(Collider other)
    {
        mainScript.win = false;
        Debug.Log("Game Over! You sounded the alarms");
        //mainScript.audioSource.Play();
        mainScript.LTGameEnd();
    }
}
