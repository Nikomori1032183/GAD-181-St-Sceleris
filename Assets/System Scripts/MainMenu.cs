using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Button startButton, exitButton;

    void Start()
    {
        //Button[] buttons = GetComponentsInChildren<Button>();
        //startButton = buttons[0];
        //exitButton = buttons[1];

        //startButton.onClick.AddListener(PlayButton);
        //exitButton.onClick.AddListener(ExitButton);

        Debug.Log("Main Menu EXISTS");

        //SceneManager.LoadScene("GameLogic");
        //SceneManager.LoadScene("MainScene");
    }

    void Update()
    {
        
    }

    // Play - Open Level Select
    public void PlayButton()
    {
        Debug.Log("Play Button Click");

        SceneLoader.current.LoadScene("LevelSelect");
        SceneLoader.current.UnloadScene("MainMenu");
    }

    // Exit - Close Application
    public void ExitButton()
    {
        Debug.Log("Exit Button Click");

        EventManager.current.MainMenuExit();

        Application.Quit();
    }
}