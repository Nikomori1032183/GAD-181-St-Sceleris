using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VInspector;

public class SceneLoader : MonoBehaviour
{

    void Start()
    {
        // Event Hooks
        EventManager.current.onMainMenuPlay += LoadLevelSelect;

        EventManager.current.onLevelSelectMainMenu += LoadMainMenu;
        EventManager.current.onClassSelect += LevelSelected;

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
        //Debug.Log(SceneManager.GetSceneByName(sceneName).isLoaded);
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
        yield return new WaitForSeconds(0.75f);

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }

    // Menu Scenes
    // Main Menu
    private void LoadMainMenu()
    {
        UnloadScene("LevelSelect");
        LoadScene("MainMenu");
    }

    // Level Select
    private void LoadLevelSelect()
    {
        UnloadScene("MainMenu");
        LoadScene("LevelSelect");
    }

    private void LevelSelected(EventManager.SelectableClasses selectedClass)
    {
        UnloadScene("LevelSelect");
    }

    // Microgame Scenes
    private void LoadMicrogameScene(string microgameSceneName)
    {
        Debug.Log("Load Microgame Scene");

        LoadScene(microgameSceneName);

        EventManager.current.MicrogameSceneLoaded();
    }

    private void UnloadMicrogameScene(string microgameSceneName)
    {
        UnloadScene(microgameSceneName);
    }

    //public string testSceneName;
    //[Button]
    //private void LoadTestScene()
    //{
    //    LoadScene(testSceneName);
    //}

    //[Button]
    //private void UnloadTestScene()
    //{
    //    UnloadScene(testSceneName);
    //}
}