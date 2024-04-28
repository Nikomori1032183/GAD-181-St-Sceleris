using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake()
    {
        current = this;
    }

    // Microgame Manager Events
    public event Action<string> onMicrogameSelected;
    public void SelectMicrogame(string microgameName)
    {
        if (onMicrogameSelected != null)
        {
            onMicrogameSelected(microgameName);
        }
    }

    // Scene Loader Events
    public event Action<Scene> onActiveSceneSet;
    public void ActiveSceneSet(Scene scene)
    {
        Debug.Log("ActiveSceneSet");

        if (onActiveSceneSet != null)
        {
            onActiveSceneSet(scene);
        }
    }

    // Microgame Events
    public event Action onDisplayObjective;
    public void DisplayObjective()
    {
        if (onDisplayObjective != null)
        {
            onDisplayObjective();
        }
    }

    public event Action onHideObjective;
    public void HideObjective()
    {
        if (onHideObjective != null)
        {
            onHideObjective();
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

    public event Action<bool> onMicrogamePlayingToggle;
    public void MicrogamePlayingToggle(bool playing)
    {
        if (onMicrogamePlayingToggle != null)
        {
            MicrogamePlayingToggle(playing);
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

    public event Action<string> onUnloadMicrogame;
    public void UnloadMicrogame(string microgameName)
    {
        if (onUnloadMicrogame != null)
        {
            onUnloadMicrogame(microgameName);
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
    public event Action<Scene> onLevelSelectLoaded;
    public void LevelSelectLoaded(Scene levelSelectScene)
    {
        if (onLevelSelectLoaded != null)
        {
            onLevelSelectLoaded(levelSelectScene);
        }
    }

    public enum SelectableClasses
    {
        Planning, Stealth, Theft, Weapons, Explosives, Escape
    }


    public event Action<SelectableClasses> onClassSelect;
    public void ClassSelect(SelectableClasses selectedClass)
    {
        Debug.Log("Class Select");
        if (onClassSelect != null)
        {
            onClassSelect(selectedClass);
        }
    }

    // Grade Menu Events
    public event Action onGradeButtonClick;

    public void GradeButtonClick()
    {
        Debug.Log("event fired");

        if (onGradeButtonClick != null)
        {
            onGradeButtonClick();
        }
    }

    // Timer Events
    public event Action onTimerStop;
    public void TimerStop()
    {
        if (onTimerStop != null)
        {
            onTimerStop();
        }
    }

    // Grab The Cash Events
    public event Action onCashCollected;
    public void CashCollected()

    {
        if (onCashCollected != null)
        {
            onCashCollected();
        }
    }
    // Button Mash Stab Events
    public event Action onGuardStab;
    public void GuardStab()
    {
        if (onGuardStab != null)
        {
            onGuardStab();
        }
    }

    // Cut the Grate Events
    public event Action onCutBar;
    public void CutBar()
    {
        if (onCutBar != null)
        {
            onCutBar();
        }
    }

    // Hide The Contraband Events
    public event Action onContrabandStashed;
    public void ContrabandStashed()
    {
        if (onContrabandStashed != null)
        {
            onContrabandStashed();
        }
    }
}