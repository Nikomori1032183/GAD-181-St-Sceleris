using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using VInspector;

public class GradeScript : MonoBehaviour
{
    //Arry of different grade images to be indexed
    [SerializeField] private Sprite[] winImages;
    [SerializeField] private Sprite activeImage;

    //Ref for image renderer
    [SerializeField] private UnityEngine.UI.Image image;

    //Enum for grades state machine
    public enum Grades {A, B, C, D, F,}
    [SerializeField] private Grades currentGrade;

    [SerializeField] private UnityEngine.UI.Image reportCard;
    [SerializeField] private Sprite reportCardSprite;

    //tick controls the opacity transition of grade
    //doMove is because there are no events. when set to true, it moves the report card. ezpz
    float tick = 0f;
    bool doMove = false;

    //V3s for moving the reportcard from point A to B
    private Vector3 screenBottom = new Vector3((Screen.width / 2), (-Screen.height * 1.5f), 0);
    private Vector3 screenMid = new Vector3((Screen.width / 2), (Screen.height / 3), 0);

    private void Start()
    {
        reportCard.sprite = reportCardSprite;               //Set the report card sprite default. this is changed at runtime
        reportCard.transform.position = screenBottom;       //Set the report card start position
        image.color = new Color(1f, 1f, 1f, 0f);            //Makes the grade image 100% transparent for the fade in

        EventManager.current.onGameComplete += ClassComplete;
    }

    private void Update()
    {
        MoveCard();
    }


    [Button]
    public void GradeButtonClick()
    {
        SetGrade(Grades.B);
    }

    private void ClassComplete(int wins)
    {
        Debug.Log("Class Complete Wins: " + wins);
        if (wins == 10)
        {
            SetGrade(Grades.A);
        }

        else if (wins >= 8)
        {
            SetGrade(Grades.B);
        }

        else if (wins >= 6)
        {
            SetGrade(Grades.C);
        }

        else if (wins >= 4)
        {
            SetGrade(Grades.D);
        }

        else
        {
            Debug.Log("F");
            SetGrade(Grades.F);
        }
    }

    //Function called when button is clicked. Activates the event, updates the image and changes the grade.
    public void SetGrade(Grades grade)
    {
        Debug.Log("SetGrade");

        //EventManager.current.GradeButtonClick();
        currentGrade = grade;

        UpdateImage();
        doMove = true;

        //Debug.Log("grade button click");
    }

    [Button]
    private void UpdateImage() //Method to update the sprite based on the grade input.
    {
        switch (currentGrade)
        {
            case Grades.A:
                image.sprite = winImages[0];
                break;
            case Grades.B:
                image.sprite = winImages[1];
                break;
            case Grades.C:
                image.sprite = winImages[2];
                break;
            case Grades.D:
                image.sprite = winImages[3];
                break;
            case Grades.F:
                image.sprite = winImages[4];
                break;
            default:
                image.sprite = winImages[4];
                break;
        }
    }

    void MoveCard() //Code based animation is fun (lie). Moves the report card to the middle of the screen and fades in the grade image
    {

        Debug.Log("Dont Move The Fucker");
        if (doMove)
        {
            Debug.Log("Move The Fucker");
            reportCard.transform.position = Vector3.MoveTowards(reportCard.transform.position, screenMid, Screen.height * Time.deltaTime);
            if (reportCard.transform.position == screenMid)
            {
                GradeBecomeVisible();
            }
        }
    }

    void GradeBecomeVisible()
        //Makes the grade become visible.
    {
        if (image.color != new Color(1f, 1f, 1f, 1f) && tick < 10.1f)
        {
            tick += (Time.deltaTime * 5);
            //Debug.Log(tick);
            image.color = Color.LerpUnclamped(new Color(1f, 1f, 1f, 0f), new Color(1f, 1f, 1f, 1f), tick/10);
        }
        if (image.color == new Color(1f, 1f, 1f, 1f))
        {
            EventManager.current.GradePresented();
        }
    }
}