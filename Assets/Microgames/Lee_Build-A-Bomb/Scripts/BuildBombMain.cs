using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBombMain : Microgame
{
    [SerializeField] List<CorrectPositions> positions;
    int pieces = 0;

    protected override void Start()
    {
        base.Start();
        //Debug.Log(pieces);
        EventManager.current.onPieceCorrect += PieceCollected;
    }

    void Update()
    {
        
    }

    protected override void PlayMicrogame()
    {
        Debug.Log(pieces);
        base.PlayMicrogame();
    }
    protected override void StopMicrogame()
    {
        pieces = 0;
        base.StopMicrogame();
    }
    private void PieceCollected()
    {
        pieces++;

        Debug.Log(pieces);

        if (pieces >= positions.Count)
        {
            Debug.Log("Win");
            result = true;
            StopMicrogame();
        }
    }
}
