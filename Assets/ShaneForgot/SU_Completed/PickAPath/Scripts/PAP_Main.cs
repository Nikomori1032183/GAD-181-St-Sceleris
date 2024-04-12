using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PAP_Main : Microgame
{
    int PAP_Counter = 0;
    public List<PAP_Door> doorOptions;
    PAP_Door doorScript;
    public static PAP_Toggle currentDoor;
    public bool PAPInPlay = false;
    public GameObject gameOver;
    public GameObject gameStart;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if (doorOptions == null)
        {
            doorOptions.Add(FindObjectOfType<PAP_Door>());
        }
        Debug.Log("Just need to fix flashing lights");
    }

    void newDoor() //random door is assigned to be safe
    {
        PAP_Counter++; //Round Counter increases
        Debug.Log("Round " + PAP_Counter);

        int rnd = Random.Range(0, 3);
        Debug.Log("New correct door (door " + doorOptions[rnd].name + ")");
        doorOptions[rnd].safe = true;
        Debug.Log(doorOptions[rnd]);


        foreach (PAP_Door door in doorOptions)
        {
            if (door.doorAudio != null)
            {
                door.doorAudio.Stop();
            }
            door.resetDoorEffect();
            door.newDoorAudio();
            door.newDoorLight();
        }
    }

    void wrongDoor()
    {
        PAP_Counter = 0;
        failClass();
    }

    void correctDoor()
    {
        Debug.Log("Nice; You made it past this door");
        currentDoor.door.safe = false;
        currentDoor.Deselect();
        if (PAP_Counter == 3)
        {
            passClass();
            return;
        }
        newDoor();
    }

    public void enterDoor(Button button)
    {
        if (currentDoor.door.safe == true && PAPInPlay)
        {
            correctDoor();
        }
        else if (currentDoor.door.safe == false && PAPInPlay)
        {
            wrongDoor();
        }
        else
        {
            button.interactable = false;
        }
    }

    public void startClass()
    {
        Debug.Log("Class Begins");
        gameStart.SetActive(false);
        PAPInPlay = true;
        newDoor();
    }
    public void passClass()
    {
        PAPInPlay = false;
        gameOver.SetActive(true);
        gameOver.GetComponentInChildren<TextMeshProUGUI>().text = "Passed Class";
        result = true;
        StopMicrogame();
    }
    public void failClass()
    {
        PAPInPlay = false;
        currentDoor.Deselect();
        gameOver.SetActive(true);
        gameOver.GetComponentInChildren<TextMeshProUGUI>().text = "Failed Class";
        result = false;
        StopMicrogame();
    }

    protected override void PlayMicrogame()
    {
        base.PlayMicrogame();
        startClass();
    }

    protected override void StopMicrogame()
    {
        base.StopMicrogame();
    }
}
