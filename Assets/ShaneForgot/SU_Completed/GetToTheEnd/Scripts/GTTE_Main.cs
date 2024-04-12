using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GTTE_Main : MonoBehaviour
{
    public GameObject spotlight;

    public GameObject StartInfo;
    public GameObject GradeMenu;
    Slider slider;

    Vector3 top = new Vector3(15, 7.26f, -8.18f);
    Vector3 mid = new Vector3(15, 4.38f, -8.18f);
    Vector3 bottom = new Vector3(15, 1.5f, -8.18f);
    List<Vector3> spawnPos = new List<Vector3>();
    Quaternion rotation = new Quaternion(0, 0, 0, 0);

    public static bool GTTEPlaying = false;
    public static bool GTTENoticed = false;
    bool pass = false;
    float timePassed = 0;

    // Start is called before the first frame update
    void Start()
    {
        //base.Start();
        //
        if (slider == null) slider = GetComponentInChildren<Slider>();
        StartInfo.SetActive(true);
        spawnPos.Add(top); spawnPos.Add(mid); spawnPos.Add(bottom);
    }

    // Update is called once per frame
    void Update()
    {
        if (GTTEPlaying)
        {
            slider.value += 0.00025f; //a little less then 15 seconds
            timePassed += Time.deltaTime;
            if (slider.value >= 1)
            {
                pass = true;
                EndGTTE();
            }
            else if (GTTENoticed)
            {
                pass = false;
                EndGTTE();
            }
            if (timePassed > 1f)
            {
                timePassed = 0;
                SpawnSpotLights();
            }
        }
    }

    public void StartGTTE()
    {
        Debug.Log("Class starting");
        StartInfo.SetActive(false);
        GTTEPlaying = true;
    }

    public void SpawnSpotLights()
    {
        int rnd = Random.Range(0, 3);
        Instantiate(spotlight, spawnPos[rnd], rotation);
        Debug.Log("Spawn light");
    }

    public void EndGTTE()
    {
        GTTEPlaying = false;
        GradeMenu.SetActive(true);
        if (pass)
        {
            Debug.Log("Passed Class");
            GradeMenu.GetComponentInChildren<GameObject>().GetComponentInChildren<GameObject>(name == "pass").gameObject.SetActive(true);
            //result = true;
        }
        else
        {
            Debug.Log("Failed Class");
            GradeMenu.GetComponentInChildren<GameObject>().GetComponentInChildren<GameObject>(name == "fail").gameObject.SetActive(true);
            //result = false;
        }
        //StopMicrogame();
    }
    /*
    protected override void PlayMicrogame()
    {
        base.PlayMicrogame();
        StartGTTE();
    }

    protected override void StopMicrogame()
    {
        base.StopMicrogame();
    }
    */
}

