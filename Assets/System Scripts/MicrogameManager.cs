using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MicrogameManager : MonoBehaviour
{
    private Microgame currentMicrogame;
    private string currentMicrogameName;

    private int wins = 0;

    private List<string> currentMicrogameClass;

    private List<string> planningMicrogames = new List<string>
    {
        "m1",
        "m2",
        "m3",
        "m4",
        "m5",
        "m6"
    };

    private List<string> steathMicrogames = new List<string>
    {
        "m1",
        "m2",
        "m3",
        "m4",
        "m5",
        "m6"
    };

    private List<string> theftMicrogames = new List<string>
    {
        "Lockpicking",
        "m2",
        "m3",
        "m4",
        "m5",
        "m6"
    };

    private List<string> weaponsMicrogames = new List<string>
    {
        "m1",
        "m2",
        "m3",
        "m4",
        "m5",
        "m6"
    };

    private List<string> explosivesMicrogames = new List<string>
    {
        "m1",
        "m2",
        "m3",
        "m4",
        "m5",
        "m6"
    };

    private List<string> escapeMicrogames = new List<string>
    {
        "m1",
        "m2",
        "m3",
        "m4",
        "m5",
        "m6"
    };

    void Start()
    {
        EventManager.current.onClassSelect += SelectClass;
        EventManager.current.onMicrogameStop += MicrogameFinished;
    }

    private void SelectRandomMicrogame()
    {
        currentMicrogameName = currentMicrogameClass[Random.Range(0, currentMicrogameClass.Count)];
        EventManager.current.SelectMicrogame(currentMicrogameName);

        currentMicrogame = FindObjectOfType<Microgame>();
        Debug.Log(currentMicrogameName);
    }

    private void LoadMicrogame()
    {
        // Select Microgame
        SelectRandomMicrogame();

        // Start Microgame
        currentMicrogame.StartMicrogame();

        // Remove Microgame From List
        currentMicrogameClass.Remove(currentMicrogameName);
    }

    private void MicrogameFinished(bool result)
    {
        if (result)
        {
            wins++;
        }

        if (currentMicrogameClass.Count > 0)
        {
            LoadMicrogame();
        }

        else
        {
            // Show class grade screen
        }
    }

    private void SelectClass(EventManager.SelectableClasses selectedClass)
    {
        switch(selectedClass)
        {
            case EventManager.SelectableClasses.Planning:
                Debug.Log("Planning Microgames Selected");
                currentMicrogameClass = planningMicrogames;
                break;

            case EventManager.SelectableClasses.Stealth:
                Debug.Log("Stealth Microgames Selected");
                currentMicrogameClass = steathMicrogames;
                break;

            case EventManager.SelectableClasses.Theft:
                Debug.Log("Theft Microgames Selected");
                currentMicrogameClass = theftMicrogames;
                break;

            case EventManager.SelectableClasses.Weapons:
                Debug.Log("Weapons Microgames Selected");
                currentMicrogameClass = weaponsMicrogames;
                break;

            case EventManager.SelectableClasses.Explosives:
                Debug.Log("Explosives Microgames Selected");
                currentMicrogameClass = explosivesMicrogames;
                break;

            case EventManager.SelectableClasses.Escape:
                Debug.Log("Escape Microgames Selected");
                currentMicrogameClass = escapeMicrogames;
                break;
        }

        LoadMicrogame();
    }
}