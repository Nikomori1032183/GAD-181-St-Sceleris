using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LT_Main : Microgame
{
    public AudioSource audioSource;

    public GameObject gameStart;
    public GameObject gameEnd;
    LT_Laser laserScript;
    public bool win;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
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
        result = win;
        StopMicrogame();
    }

    protected override void PlayMicrogame()
    {
        base.PlayMicrogame();
        LTGamePlay();
    }

    protected override void StopMicrogame()
    {
        base.StopMicrogame();
    }
}
