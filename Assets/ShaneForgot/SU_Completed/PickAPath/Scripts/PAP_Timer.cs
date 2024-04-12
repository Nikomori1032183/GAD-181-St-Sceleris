using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VInspector.Libs;

public class PAP_Timer : MonoBehaviour
{
    float timeRemaining = 20;
    public TMP_Text textMeshPro;
    public Light policeLight;
    public PAP_Main mainScript;

    // Start is called before the first frame update
    void Start()
    {
        if (mainScript == null) mainScript = FindObjectOfType<PAP_Main>();
        if (textMeshPro == null) textMeshPro = GetComponent<TextMeshProUGUI>();
        policeLight.range = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0 && mainScript.PAPInPlay)
        {
            runTimer();
        }
        else if (timeRemaining <= 0 && mainScript.PAPInPlay)
        {
            Debug.Log("Game Over! You ran out of time and got caught!");
            mainScript.failClass();
        }
    }

    void runTimer()
    {
        timeRemaining -= Time.deltaTime;
        policeLight.range += Time.deltaTime;
        textMeshPro.text = timeRemaining.Round() + " Seconds Left";
    }
}
