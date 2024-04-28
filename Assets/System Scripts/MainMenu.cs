using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Button startButton, exitButton;

    void Start()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        startButton = buttons[0];
        exitButton = buttons[1];

        startButton.onClick.AddListener(PlayButton);
        exitButton.onClick.AddListener(ExitButton);
    }

    void Update()
    {
        
    }

    // Play - Open Level Select
    private void PlayButton()
    {
        Debug.Log("Play Button Click");

        SceneLoader.current.LoadScene("LevelSelect");
        SceneLoader.current.UnloadScene("MainMenu");
    }

    // Exit - Close Application
    private void ExitButton()
    {
        Debug.Log("Exit Button Click");

        EventManager.current.MainMenuExit();

        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}