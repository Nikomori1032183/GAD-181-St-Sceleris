using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LT_WinTrigger_SU : MonoBehaviour
{
    LT_Main mainScript;

    void Start()
    {
        mainScript = FindAnyObjectByType<LT_Main>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            mainScript.LTGameEnd();
            Debug.Log("You Win!");
        }
    }
}
