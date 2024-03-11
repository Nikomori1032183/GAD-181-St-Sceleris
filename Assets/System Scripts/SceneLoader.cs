using System.Collections;
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

        //LoadScene("UserInterface");
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
    }

    // Unload Scene
    private void UnloadScene(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName) != null)
        {
            SceneManager.UnloadSceneAsync(sceneName);
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

}
