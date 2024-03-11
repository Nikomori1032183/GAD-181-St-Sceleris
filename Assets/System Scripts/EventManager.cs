using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake()
    {
        current = this;
    }

    // Microgame Events
    public event Action<string, float> onDisplayObjective;
    public void DisplayObjective(string objectiveName, float objectiveTime)
    {
        if (onDisplayObjective != null)
        {
            onDisplayObjective(objectiveName, objectiveTime);
        }
    }

    public event Action<float> onMicrogamePlay;
    public void MicrogamePlay(float playTime)
    {
        if (onMicrogamePlay != null)
        {
            onMicrogamePlay(playTime);
        }
    }

    public event Action<bool> onMicrogameStop;
    public void MicrogameStop(bool result)
    {
        if (onMicrogameStop != null)
        {
            onMicrogameStop(result);
        }
    }

    // Main Menu Events
    public event Action onMainMenuPlay;
    public void MainMenuPlay()
    {
        if (onMainMenuPlay != null)
        {
            onMainMenuPlay();
        }
    }

    public event Action onMainMenuExit;
    public void MainMenuExit()
    {
        if (onMainMenuExit != null)
        {
            onMainMenuExit();
        }
    }

    // Level Select Events
    public event Action onLevelSelectMainMenu;
    public void LevelSelectMainMenu()
    {
        if (onLevelSelectMainMenu != null)
        {
            onLevelSelectMainMenu();
        }
    }

    public enum SelectableClasses
    {
        Planning, Stealth, Theft, Weapons, Explosives, Escape
    }


    public event Action<SelectableClasses> onClassSelect;
    public void ClassSelect(SelectableClasses selectedClass)
    {
        if (onClassSelect != null)
        {
            onClassSelect(selectedClass);
        }
    }
}