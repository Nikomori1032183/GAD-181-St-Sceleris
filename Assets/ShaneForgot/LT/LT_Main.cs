using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LT_Main : MonoBehaviour
{
    public GameObject gameStart;
    public GameObject gameEnd;
    LT_Laser laserScript;

    // Start is called before the first frame update
    void Start()
    {
        laserScript = FindAnyObjectByType<LT_Laser>();
        laserScript.groupLasers();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LTGamePlay()
    {
        LT_Player_SU.inPlay = true;
        LT_Player_SU.audioSource.Play();
        laserScript.laserOn(true);
        gameStart.SetActive(false);
    }

    public void LTGameEnd() 
    {
        LT_Player_SU.inPlay = false;
        LT_Player_SU.audioSource.Stop();
        laserScript.laserOn(false);
        gameEnd.SetActive(true);
    }
}
