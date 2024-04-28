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
    private enum grades {A, B, C, D, F,}
    [SerializeField] private grades grade = grades.A;

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
        
    }

    private void Update()
    {
        MoveCard();
    }

    public void GradeButtonClick()
        //Function called when button is clicked. Activates the event, updates the image and changes the grade.
    {
        EventManager.current.GradeButtonClick();
        UpdateImage(ChangeGrade(grades.A));         //THIS IS A DEFAULT CASE. CHANGE FROM A WHEN YOU IMPLEMENT
        doMove = true;
        //Debug.Log("grade button click");
    }

    Sprite ChangeGrade(grades grade)
        //switch case accessed when grades are requested to be shown. Returns the relvant image as a sprite which is displayed
    {
        switch (grade)
        {
            case grades.A:
                activeImage = winImages[0];
                return activeImage;
            case grades.B:
                activeImage = winImages[1];
                return activeImage;
            case grades.C:
                activeImage = winImages[2];
                return activeImage;
            case grades.D:
                activeImage = winImages[3];
                return activeImage;
            case grades.F:
                activeImage = winImages[4];
                return activeImage;
            default:
                activeImage = winImages[0];
                return activeImage;
        }
    }

    [Button]
    private void UpdateImage(Sprite sprite)
        //Method to update the sprite based on the grade input.
    {
        image.sprite = ChangeGrade(grades.A);       //THIS IS A DEFAULT CASE. CHANGE FROM A WHEN YOU IMPLEMENT
    }

    void MoveCard()
        //Code based animation is fun (lie). Moves the report card to the middle of the screen and fades in the grade image
    {
        if (doMove)
        {
            reportCard.transform.position = Vector3.MoveTowards(reportCard.transform.position, screenMid, Screen.height * Time.deltaTime);
            if (reportCard.transform.position == screenMid)
            {
                GradeBecomeVisible();
            }
        }
    }

    void GradeBecomeVisible()
        //Mkaes the grade become visible.
    {
        if (image.color != new Color(1f, 1f, 1f, 1f) && tick < 10.1f)
        {
            tick += (Time.deltaTime * 5);
            Debug.Log(tick);
            image.color = Color.LerpUnclamped(new Color(1f, 1f, 1f, 0f), new Color(1f, 1f, 1f, 1f), tick/10);
        }
    }
}
