using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    Button startButton, exitButton;

    // Start is called before the first frame update
    void Start()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        startButton = buttons[0];
        exitButton = buttons[1];

        startButton.onClick.AddListener(PlayButton);
        exitButton.onClick.AddListener(ExitButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Play - Open Level Select
    private void PlayButton()
    {
        Debug.Log("Play Button Click");

        EventManager.current.MainMenuPlay();
    }

    // Exit - Close Application
    private void ExitButton()
    {
        Debug.Log("Exit Button Click");

        EventManager.current.MainMenuExit();
    }
}