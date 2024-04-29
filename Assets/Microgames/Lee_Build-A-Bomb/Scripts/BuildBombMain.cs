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
        bool complete = true;
        foreach (CorrectPositions position in positions)
        {
            if (position.inPos == false)
            {
                complete = false;
            }
        }
        

        Debug.Log(complete);
        result = complete;
    }
}
