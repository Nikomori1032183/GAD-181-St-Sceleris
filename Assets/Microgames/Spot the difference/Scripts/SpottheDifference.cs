using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpotheDifference : Microgame
{
    [SerializeField] ChangeColourOnClick diffBomb;
    [SerializeField] int bombPartHighlight = 3;
    int bombPartHighlighted = 0;
    bool playing;

    override protected void Start()
    {
        base.Start();

        InputManager.current.onLeftClickDown += HighlightObject;
        EventManager.current.onDiffBombHighlight += BombRed;
    }
    override protected void PlayMicrogame()
    {
        base.PlayMicrogame();
        playing = true;
    }

    override protected void StopMicrogame()
    {
        base.StopMicrogame();
        playing = false;
    }

    void BombRed()
    {
        if (playing)
        {
            if (!diffBomb.GetComponent<Renderer>())
            {
                diffBomb = null;
            }
        }
    }

    void HighlightObject()
    {
        bombPartHighlighted++;
        Debug.Log(bombPartHighlighted);


        if(bombPartHighlighted >= bombPartHighlight)
        {
            result = true;
            Debug.Log("You Win!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
