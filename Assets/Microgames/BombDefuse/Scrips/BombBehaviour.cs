using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using VInspector;

public class BombBehaviour : Microgame
{
    int[] codeSolution = new int[5];
    List<int> codeInput = new List<int>();
    private int iterator = 0;
    private bool failure = false;

    private TextMeshPro bombdisplay;
    //KeyPos array positions defined in the eidot. Please dont make me do it again.
    [SerializeField] private Vector3[] keyPos = new Vector3[12];
    [SerializeField] private GameObject[] keys = new GameObject[12];

    [SerializeField] private TextMeshPro bombcode;
    [SerializeField] private TextMeshPro bombStatus;


    protected override void Start()
    {
        base.Start();
        ShowCode(GeneratedCodeToNote(GenerateCodePuzzle()));
        AssignKeyPositions();
        SetBombStatus();
        PlayMicrogame();
        
    }
    protected override void PlayMicrogame()
    {
        base.PlayMicrogame();
    }
    protected override void StopMicrogame()
    {
        base.StopMicrogame();
    }
    #region keyinput
    public void RecieveInput(int keyPressed)
    {
        if (iterator < 5 && !failure)
        {
            iterator++;
            codeInput.Add(keyPressed);
            Debug.Log("Key Pressed: " + codeInput[codeInput.Count - 1]);
            Debug.Log("Key you needed to press: " + codeSolution[iterator - 1]);
            if (codeInput[codeInput.Count - 1] == codeSolution[iterator - 1])
            {
                Debug.Log("Good");
            }
            else if (codeInput[codeInput.Count - 1] != codeSolution[iterator - 1])
            {
                bombStatus.text = "BOOM!";
                bombStatus.color = Color.red;
                failure = true;
                StopMicrogame();
            }
        }
        if (codeInput.Count == 5 && !failure)
        {
            bombStatus.text = "SAFE";
            bombStatus.color = Color.green;
            result = true;
            StopMicrogame();
        }
    }
    #endregion

    #region randomize key positions
    [Button]
    void AssignKeyPositions()
    {
        List<Vector3> listKeyPos = keyPos.ToList();
        List<Vector3> randomListKeyPos = new List<Vector3>();
        List<int> numberList = new List<int>();

        for (int num = 0; num < listKeyPos.Count; num++)
        {
            numberList.Add(num);
        }

        foreach (Vector3 pos in listKeyPos)
        {
            int i = Random.Range(0, numberList.Count);
            int numberToRemove = numberList[i];

            randomListKeyPos.Add(listKeyPos[numberToRemove]);

            numberList.Remove(numberToRemove);

        }
        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].transform.localPosition = randomListKeyPos[i];
        }
    }
    #endregion

    #region bomb code generation and display
    int[] GenerateCodePuzzle()
        //Randomly Generates a code of numbers from 0 - 9
    {
        int i = 0;
        for (i = 0; i < codeSolution.Length; i++)
        {
            codeSolution[i] = Random.Range(0, 10);
        }
        if (i == codeSolution.Length)
        {
            return codeSolution;
        }
        else
        {
            return null;
        }
    }

    void ShowCode(string code)
        //Writes the bombcode to the textmeshpro on the sticknote
    {
        bombcode.text = GeneratedCodeToNote(codeSolution);
    }

    string GeneratedCodeToNote(int[] bombcode)
        //What is says on the tin. Turns the code into a string to be written on the note.
    {
        string str = string.Join(" ", bombcode);
        return str;
    }
    void SetBombStatus()
    {
        bombStatus.text = "ARMED";
        bombStatus.color = new Color(255, 120, 0, 255);
    }
    #endregion

}
