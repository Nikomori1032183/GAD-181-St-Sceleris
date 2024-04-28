using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VInspector;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader current;

    void Start()
    {
        current = this;

        SceneManager.sceneLoaded += SetActiveScene;
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
            Debug.Log(sceneName + "Scene Unloaded");
        }

        else
        {
            Debug.Log(sceneName + "Scene Unable To Unload");
        }
    }

    public void SetActiveScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        SceneManager.SetActiveScene(scene);
    }

    public void UnloadActiveScene()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        UnloadScene(activeSceneName);
        Debug.Log(activeSceneName + "Scene Unloaded");
    }
}