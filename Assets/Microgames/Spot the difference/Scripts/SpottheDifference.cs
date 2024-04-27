using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpotheDifference : Microgame
{
    [SerializeField] ChangeColourOnClick diffBomb;

    override protected void Start()
    {
        base.Start();

        InputManager.current.onLeftClickDown += HighlightObject;
        EventManager.current.onDiffBombHighlight += BombRed;
    }
    override protected void PlayMicrogame()
    {
        base.PlayMicrogame();
    }

    override protected void StopMicrogame()
    {
        base.StopMicrogame();
    }

    void HighlightObject()
    {
        if (playing)
        {
            if (!diffBomb.GetComponent<Renderer>())
            {
                diffBomb = null;
            }
        }
    }

    void BombRed()
    {

    }
}
