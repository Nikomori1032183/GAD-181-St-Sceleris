using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GTTE_Main : Microgame
{
    public GameObject spotlight;
    AudioSource audioSource;
    GTTE_Player player;

    public GameObject StartInfo;
    public GameObject GradeMenu;
    Slider slider;

    bool start = true;
    float startX_1 = 3f;
    float startX_2 = 9f;

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
    protected override void Start()
    {
        base.Start();
        //
        if (slider == null) slider = GetComponentInChildren<Slider>();
        if (player == null) player = FindAnyObjectByType<GTTE_Player>();
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
        StartInfo.SetActive(true);
        spawnPos.Add(bottom); spawnPos.Add(mid); spawnPos.Add(top);
    }

    // Update is called once per frame
    void Update()
    {
        if (GTTEPlaying)
        {
            if (start == true)
            {
                int rnd = Random.Range(0, 3);
                Vector3 temp = new Vector3(startX_1, spawnPos[rnd].y, spawnPos[rnd].z);
                Instantiate(spotlight, temp, rotation);
                rnd = Random.Range(0, 3);
                temp = new Vector3(startX_2, spawnPos[rnd].y, spawnPos[rnd].z);
                Instantiate(spotlight, temp, rotation);
                start = false;
            }
            //sliderStart += Time.deltaTime;
            slider.value += 0.00023f; //0.00025 = a little less then 15 seconds
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
            if (timePassed > 1.5f) //1.25 is the perfect speed
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
        player.playerAudioSource.Play();
        SpawnSpotLights();
    }

    public void SpawnSpotLights()
    {
        int rnd = Random.Range(0, 3);
        Instantiate(spotlight, spawnPos[rnd], rotation);
        Debug.Log("Spawn light at: " + spawnPos[rnd]);
    }

    public void EndGTTE()
    {
        player.playerAudioSource.Stop();
        GTTEPlaying = false;
        GradeMenu.SetActive(true);
        if (pass)
        {
            audioSource.Play();
            Debug.Log("Passed Class");
            //GradeMenu.GetComponentInChildren<GameObject>().GetComponentInChildren<GameObject>(name == "pass").gameObject.SetActive(true);
            result = true;
        }
        else
        {
            Debug.Log("Failed Class");
            //GradeMenu.GetComponentInChildren<GameObject>().GetComponentInChildren<GameObject>(name == "fail").gameObject.SetActive(true);
            result = false;
        }
        StopMicrogame();
    }
    protected override void PlayMicrogame()
    {
        base.PlayMicrogame();
        StartGTTE();
    }

    protected override void StopMicrogame()
    {
        base.StopMicrogame();
    }
}

