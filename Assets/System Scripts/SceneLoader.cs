using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VInspector;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader current;

    void Awake()
    {
        current = this;

        Debug.Log("SCENE LOADER EXISTS");

        SceneManager.sceneLoaded += SetActiveScene;

        LoadScene("MainScene");
        LoadScene("Microgame UI");
        LoadScene("MainMenu");
    }

    // Load Scene By Name
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        Scene scene = SceneManager.GetSceneByName(sceneName);
        Debug.Log(sceneName + "Scene Loaded");
    }

    // Unload Scene By Name
    public void UnloadScene(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName) != null)
        {
            SceneManager.UnloadSceneAsync(sceneName);
            //Debug.Log(sceneName + "Scene Unloaded");
        }

        else
        {
            Debug.Log(sceneName + "Scene Unable To Unload");
        }
    }

    public void UnloadScene(Scene scene)
    {
        if (scene != null)
        {
            SceneManager.UnloadSceneAsync(scene);
            //Debug.Log(scene.name + "Scene Unloaded");
        }

        else
        {
            Debug.Log(scene.name + "Scene Unable To Unload");
        }
    }

    public void SetActiveScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        SceneManager.SetActiveScene(scene);
        EventManager.current.ActiveSceneSet(scene);
    }

    public void UnloadActiveScene()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        UnloadScene(activeSceneName);
        //Debug.Log(activeSceneName + "Scene Unloaded");
    }
}