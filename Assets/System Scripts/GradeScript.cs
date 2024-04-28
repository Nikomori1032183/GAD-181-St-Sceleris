using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using VInspector;

public class GradeScript : MonoBehaviour
{
    [SerializeField] private Sprite[] winImages;
    [SerializeField] private Sprite activeImage;
    [SerializeField] private UnityEngine.UI.Image image;
    private enum grades {A, B, C, D, F,}
    [SerializeField] private grades grade = grades.A;

    private void Start()
    {
    }

    public void GradeButtonClick()
    {
        EventManager.current.GradeButtonClick();
        Debug.Log("grade button click");
    }

    Sprite ChangeGrade()
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
    private void UpdateImage()
    {
        image.sprite = ChangeGrade();
    }
}
