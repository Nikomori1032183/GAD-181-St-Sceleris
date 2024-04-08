using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    void Start()
    {
        // Event Hooks
        EventManager.current.onMainMenuPlay += LoadLevelSelect;
        EventManager.current.onMainMenuPlay += UnloadMainMenu;

        EventManager.current.onLevelSelectMainMenu += LoadMainMenu;
        EventManager.current.onLevelSelectMainMenu += UnloadLevelSelect;

        EventManager.current.onMicrogameSelected += LoadMicrogameScene;
    }

    void Update()
    {

    }

    // Load Scene
    private void LoadScene(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName) != null)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }

        else
        {
            Debug.Log("Scene Name Not Found");
        }
    }

    // Unload Scene
    private void UnloadScene(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName) != null)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }

        else
        {
            Debug.Log("Scene Name Not Found");
        }
    }

    // Menu Scenes
    // Main Menu
    private void LoadMainMenu()
    {
        LoadScene("MainMenu");
    }

    private void UnloadMainMenu()
    {
        UnloadScene("MainMenu");
    }

    // Level Select
    private void LoadLevelSelect()
    {
        LoadScene("LevelSelect");
    }

    private void UnloadLevelSelect()
    {
        UnloadScene("LevelSelect");
    }

    // Microgame Scenes
    private void LoadMicrogameScene(string microgameSceneName)
    {
        LoadScene(microgameSceneName);

        EventManager.current.MicrogameSceneLoaded();
    }
}
