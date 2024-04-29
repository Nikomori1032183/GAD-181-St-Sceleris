using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBombMain : Microgame
{
    [SerializeField] List<CorrectPositions> positions;

    protected override void Start()
    {
        base.Start();
        EventManager.current.onPieceCorrect += CheckComplete;
    }

    void Update()
    {
        
    }

    protected override void PlayMicrogame()
    {
        base.PlayMicrogame();
    }
    protected override void StopMicrogame()
    {
        base.StopMicrogame();
    }

    private void CheckComplete()
    {
        Debug.Log("CheckComplete");

        bool complete = true;
        foreach (CorrectPositions position in positions)
        {
            Debug.Log("Position: " + position.inPos);
            if (position.inPos == false)
            {
                complete = false;
            }
        }
        
        if (complete)
        {
            Debug.Log("Win");
            result = complete;
            StopMicrogame();
        }
    }
}
