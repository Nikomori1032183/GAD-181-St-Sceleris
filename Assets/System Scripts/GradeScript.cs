using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeScript : MonoBehaviour
{
    [SerializeField] private Sprite[] winImages;
    private enum grades {A, B, C, D, F,}
    private grades grade;

    void DisplayGrade()
    {
        switch (grade)
        {
            case grades.A:
                break;
            case grades.B:
                break;
            case grades.C:
                break;
            case grades.D:
                break;
            case grades.F:
                break;
            default:
                break;
        }
    }
}
