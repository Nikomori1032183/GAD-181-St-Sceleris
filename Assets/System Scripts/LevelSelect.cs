using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    //Button mainMenuButton, planningButton, stealthButton, theftButton, weaponsButton, explosivesButton, escapeButton;
    [SerializeField] private Button theftButton;

    void Start()
    {
        Button[] buttons = GetComponentsInChildren<Button>();

        // Main Menu
        //mainMenuButton = buttons[0];

        //mainMenuButton.onClick.AddListener(MainMenuButton);

        //I'm so sorry but I have to root thru all this because we depreciated like, most of the buttons 
        //  and now I deleted the wrong one and these aren't serialized so I gotta go edit code now. - Nik
        //PS if you ever make an array that stores EDITABLE objects and you don't make it serialized I will
        //  BOIL you. :D

        // Classes
        //planningButton = buttons[1];
        //stealthButton = buttons[2];
        //theftButton = buttons[3];
        //weaponsButton = buttons[4];
        //explosivesButton = buttons[5];
        //escapeButton = buttons[6];

        //planningButton.onClick.AddListener(PlanningButton);
        //stealthButton.onClick.AddListener(StealthButton);
        theftButton.onClick.AddListener(TheftButton);
        //weaponsButton.onClick.AddListener(WeaponsButton);
        //explosivesButton.onClick.AddListener(ExplosivesButton);
        //escapeButton.onClick.AddListener(EscapeButton);
    }

    private void MainMenuButton() // Return to Main Menu
    {
        Debug.Log("Main Menu Click");
        SceneLoader.current.LoadScene("MainMenu");
        SceneLoader.current.UnloadScene("LevelSelect");
    }

    private void PlanningButton() // Select Planning Class
    {
        Debug.Log("Planning Click");
        EventManager.current.ClassSelect(EventManager.SelectableClasses.Planning);
        SceneLoader.current.UnloadScene("LevelSelect");
    }

    private void StealthButton() // Select Stealth Class
    {
        Debug.Log("Stealth Click");
        EventManager.current.ClassSelect(EventManager.SelectableClasses.Stealth);
        SceneLoader.current.UnloadScene("LevelSelect");
    }

    private void TheftButton() // Select Theft Class
    {
        Debug.Log("Theft Click");
        EventManager.current.ClassSelect(EventManager.SelectableClasses.Theft);
        SceneLoader.current.UnloadScene("LevelSelect");
    }

    private void WeaponsButton() // Select Weapons Class
    {
        Debug.Log("Weapons Click");
        EventManager.current.ClassSelect(EventManager.SelectableClasses.Weapons);
        SceneLoader.current.UnloadScene("LevelSelect");
    }

    private void ExplosivesButton() // Select Explosives Class
    {
        Debug.Log("Explosives Click");
        EventManager.current.ClassSelect(EventManager.SelectableClasses.Explosives);
        SceneLoader.current.UnloadScene("LevelSelect");
    }

    private void EscapeButton() // Select Escape Class
    {
        Debug.Log("Escape Click");
        EventManager.current.ClassSelect(EventManager.SelectableClasses.Escape);
        SceneLoader.current.UnloadScene("LevelSelect");
    }
}