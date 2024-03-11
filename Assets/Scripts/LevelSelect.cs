using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    Button mainMenuButton, planningButton, stealthButton, theftButton, weaponsButton, explosivesButton, escapeButton;

    void Start()
    {
        Button[] buttons = GetComponentsInChildren<Button>();

        mainMenuButton = buttons[0];



        mainMenuButton.onClick.AddListener(MainMenuButton);
    }

    private void Update()
    {

    }

    // Main Menu - Return to Main Menu
    private void MainMenuButton()
    {
        Debug.Log("Main Menu Click");

        EventManager.current.LevelSelectMainMenu();
    }
}
