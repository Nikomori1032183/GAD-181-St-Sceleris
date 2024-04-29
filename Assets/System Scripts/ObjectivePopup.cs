using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VInspector;

public class ObjectivePopup : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;

    [SerializeField] private int moveSpeed = 500;
    private RectTransform iTransform;

    private Vector3 displayPos = new Vector3(Screen.width/2, Screen.height/2, 0);
    private Vector3 hidePos = new Vector3(Screen.width/2, -Screen.height, 0);

    private Image image;

    private bool display = false;

    private bool hasMoved = false;

    private void Start()
    {
        iTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        Debug.Log(iTransform.position);
        Debug.Log(displayPos);
        Debug.Log(hidePos);
        EventManager.current.onPopup += StartPopup;
        EventManager.current.onMicrogameSelected += SetMicrogamePopup;
    }


    void Update()
    {
        if (display)
        {
            Display();
        }

        else
        {
            Hide();
        }
    }

    private void SetMicrogamePopup(string microgameName)
    {
        Debug.Log("Trying To Set" + microgameName);

        switch (microgameName)
        {
            case "GrabTheCash":
                SetSprite(sprites[0]);
                break;
            case "HideTheContraband":
                SetSprite(sprites[1]);
                break;
            case "CutTheGrate":
                SetSprite(sprites[2]);
                break;
            case "BombDefuse":
                SetSprite(sprites[3]);
                break;
            case "Build-A-Bomb":
                SetSprite(sprites[4]);
                break;
            case "LaserTrap":
                SetSprite(sprites[5]);
                break;
            case "PickAPath":
                SetSprite(sprites[6]);
                break;
            case "GetToTheEnd":
                SetSprite(sprites[7]);
                break;
            case "SpotTheDifference":
                SetSprite(sprites[8]);
                break;
            case "ButtonMashStab":
                SetSprite(sprites[9]);
                break;
            case "Build-A-Gun":
                SetSprite(sprites[10]);
                break;
            case "LockPick":
                SetSprite(sprites[11]);
                break;
        }
    }

    void StartPopup(float displayTime)
    {
        Debug.Log("StartPopup");
        StartCoroutine(Popup(displayTime));
    }

    IEnumerator Popup(float displayTime)
    {
        DisplayObjective();

        yield return new WaitForSeconds(displayTime);

        HideObjective();

        EventManager.current.PopUpFinished();
    }

    [Button]
    void DisplayObjective()
    {
        Debug.Log("DisplayObjective");
        display = true;
    }

    [Button]
    void HideObjective()
    {
        Debug.Log("HideObjective");
        display = false;
    }

    void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }

    void Display()
    {
        if (!hasMoved && iTransform.position != displayPos)
        {
            transform.position = Vector3.MoveTowards(iTransform.position, displayPos, moveSpeed * Time.deltaTime);
        }

        if (!hasMoved && iTransform.position == displayPos)
        {

            hasMoved = true;
        }
    }
    void Hide()
    {
        if (hasMoved)
        {
            transform.position = Vector3.MoveTowards(iTransform.position, hidePos, moveSpeed * Time.deltaTime);
        }

        if (hasMoved && transform.position == hidePos)
        {
            hasMoved = false;
        }
    }
}
