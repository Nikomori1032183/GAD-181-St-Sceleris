using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class GradeSceneButtons : MonoBehaviour
{
    [SerializeField] Button[] buttons = new Button[2];
    private void Start()
    {
        var startButton = buttons[0];
        var exitButton = buttons[1];
        startButton.onClick.AddListener(GoToLevelSelect);
        exitButton.onClick.AddListener(ExitButton);
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(false);
        }
    }
    public void GoToLevelSelect()
    {
        SceneLoader.current.LoadScene("MainMenu");
        SceneLoader.current.UnloadScene("GradeScene");
    }

    public void ExitButton()
    {
        EventManager.current.MainMenuExit();

        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
