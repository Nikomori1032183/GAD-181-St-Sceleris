using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VInspector;

public class ObjectivePopup : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;

    [SerializeField] private int moveSpeed = 500;

    [SerializeField] private Vector3 displayPos;
    [SerializeField] private Vector3 hidePos;

    private Image image;

    private bool boolA;
    private bool boolB;

    private bool hasMoved = false;

    private void Start()
    {
        image = GetComponent<Image>();

        EventManager.current.onPopup += StartPopup;
        EventManager.current.onMicrogameSelected += SetMicrogamePopup;
    }


    void Update()
    {
        if (boolA)
        {
            Display();
        }

        if (boolB)
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
        }
    }

    void StartPopup(float displayTime)
    {
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
        boolA = true;
        boolB = false;
    }

    [Button]
    void HideObjective()
    {
        Debug.Log("HideObjective");
        boolB = true;
        boolA = false;
    }

    void SetSprite(Sprite sprite)
    {
        image.sprite = sprite;
    }

    void Display()
    {
        if (!hasMoved && transform.position != displayPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, displayPos, moveSpeed * Time.deltaTime);
        }

        if (!hasMoved && transform.position == displayPos)
        {

            hasMoved = true;
        }
    }
    void Hide()
    {
        if (hasMoved)
        {
            transform.position = Vector3.MoveTowards(transform.position, hidePos, moveSpeed * Time.deltaTime);
        }

        if (hasMoved && transform.position == hidePos)
        {
            hasMoved = false;
        }
    }
}
