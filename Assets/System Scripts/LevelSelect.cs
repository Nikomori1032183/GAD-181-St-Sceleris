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

        // Main Menu
        mainMenuButton = buttons[0];

        mainMenuButton.onClick.AddListener(MainMenuButton);

        // Classes
        planningButton = buttons[1];
        stealthButton = buttons[2];
        theftButton = buttons[3];
        weaponsButton = buttons[4];
        explosivesButton = buttons[5];
        escapeButton = buttons[6];

        planningButton.onClick.AddListener(PlanningButton);
        stealthButton.onClick.AddListener(StealthButton);
        theftButton.onClick.AddListener(TheftButton);
        weaponsButton.onClick.AddListener(WeaponsButton);
        explosivesButton.onClick.AddListener(ExplosivesButton);
        escapeButton.onClick.AddListener(EscapeButton);
    }

    private void Update()
    {

    }

    private void MainMenuButton() // Return to Main Menu
    {
        Debug.Log("Main Menu Click");
        EventManager.current.LevelSelectMainMenu();
    }

    private void PlanningButton() // Select Planning Class
    {
        Debug.Log("Planning Click");
        EventManager.current.ClassSelect(EventManager.SelectableClasses.Planning);
    }

    private void StealthButton() // Select Stealth Class
    {
        Debug.Log("Stealth Click");
        EventManager.current.ClassSelect(EventManager.SelectableClasses.Stealth);
    }

    private void TheftButton() // Select Theft Class
    {
        Debug.Log("Theft Click");
        EventManager.current.ClassSelect(EventManager.SelectableClasses.Theft);
    }

    private void WeaponsButton() // Select Weapons Class
    {
        Debug.Log("Weapons Click");
        EventManager.current.ClassSelect(EventManager.SelectableClasses.Weapons);
    }

    private void ExplosivesButton() // Select Explosives Class
    {
        Debug.Log("Explosives Click");
        EventManager.current.ClassSelect(EventManager.SelectableClasses.Explosives);
    }

    private void EscapeButton() // Select Escape Class
    {
        Debug.Log("Escape Click");
        EventManager.current.ClassSelect(EventManager.SelectableClasses.Escape);
    }
}