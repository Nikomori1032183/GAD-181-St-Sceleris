using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivePopup : MonoBehaviour
{
    private Image image;

    [SerializeField] private int moveSpeed = 500;

    private int timeToWait = 2;

    private Vector3 screenStart = new Vector3(Screen.width * 0.5f, (Screen.height - Screen.height - 200), 0);
    private Vector3 screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);

    private bool boolA;
    private bool boolB;

    private bool hasMoved = false;

    private void Start()
    {
        image = GetComponent<Image>();

        EventManager.current.onDisplayObjective += DisplayObjective;
        EventManager.current.onHideObjective += HideObjective;
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

    void DisplayObjective()
    {
        boolA = true;
        boolB = false;
    }
    
    void HideObjective()
    {
        boolB = true;
        boolA = false;
    }

    void Display()
    {
        if (!hasMoved && transform.position != screenCenter)
        {
            transform.position = Vector3.MoveTowards(transform.position, screenCenter, moveSpeed * Time.deltaTime);
        }
        if (!hasMoved && transform.position == screenCenter)
        {

            hasMoved = true;
        }
    }
    void Hide()
    {
        if (hasMoved)
        {
            transform.position = Vector3.MoveTowards(transform.position, screenStart, moveSpeed * Time.deltaTime);
        }
        if (hasMoved && transform.position == screenStart)
        {
            hasMoved = false;
        }
    }
}
