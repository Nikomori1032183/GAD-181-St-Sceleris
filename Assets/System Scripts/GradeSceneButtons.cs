using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using VInspector;

public class GradeSceneButtons : MonoBehaviour
{
    private Color opaq = new Color(1f,1f,1f,1f);
    private Color tnsp = new Color(1f, 1f, 1f, 0f);

    [SerializeField] Button[] buttons = new Button[2];
    private void Start()
    {
        EventManager.current.onGradePresented += RevealButtons;
        var startButton = buttons[0];
        var exitButton = buttons[1];
        startButton.onClick.AddListener(GoToLevelSelect);
        exitButton.onClick.AddListener(ExitButton);
        foreach (var button in buttons)
        {
            button.GetComponentInChildren<TextMeshProUGUI>().color = tnsp;
            button.image.color = tnsp;
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
    [Button]
    void RevealButtons()
    {
        buttons[0].gameObject.SetActive(true);
        buttons[1].gameObject.SetActive(true);
        StartCoroutine(ButtonAnimation());
    }
    IEnumerator ButtonAnimation()
    {
        yield return new WaitForSeconds(1.5f);
        while (buttons[0].image.color != opaq)
        {
            foreach (var button in buttons)
            {
                button.image.color = Color.Lerp(button.image.color, opaq, 4 * Time.deltaTime);
                button.GetComponentInChildren<TextMeshProUGUI>().color = Color.Lerp(button.GetComponentInChildren<TextMeshProUGUI>().color, opaq, 4 * Time.deltaTime);
            }
            yield return null;
        }
    }
}
