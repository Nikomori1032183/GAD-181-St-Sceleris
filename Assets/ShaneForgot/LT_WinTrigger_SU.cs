using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LT_WinTrigger_SU : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("You Win!");
            //Play success sound
            //fade screen to white
            //activate END PASS system
        }
    }
}
