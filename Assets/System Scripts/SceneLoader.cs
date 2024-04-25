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
        EventManager.current.onUnloadMicrogame += UnloadMicrogameScene;
    }

    // Load Scene
    private void LoadScene(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName) != null)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            
            StartCoroutine(SetActiveSceneDelayed(sceneName));
        }

        else
        {
            Debug.Log("Scene Name Not Found");
        }
    }

    // Unload Scene
    private void UnloadScene(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }

        else
        {
            Debug.Log("Scene Name Not Found");
        }
    }
    
    // Set Active
    IEnumerator SetActiveSceneDelayed(string sceneName)
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
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
        if (SceneManager.GetSceneByName("LevelSelect") != null)
        {
            UnloadScene("LevelSelect");
        }

        LoadScene(microgameSceneName);

        EventManager.current.MicrogameSceneLoaded();
    }

    private void UnloadMicrogameScene(string microgameSceneName)
    {
        UnloadScene(microgameSceneName);
    }
}