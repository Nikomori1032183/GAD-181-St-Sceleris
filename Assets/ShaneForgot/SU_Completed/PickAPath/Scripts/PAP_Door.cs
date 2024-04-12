using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PAP_Door : MonoBehaviour
{
    public float volume = 0;
    public float brightness = 0;
    public bool doorPlaying;
    Light doorLight;
    public AudioSource doorAudio;
    //AudioClip doorClip;
    public bool safe = false;
    public PAP_Audio audioScript;
    public PAP_Light lightScript;
    int rnd;

    // Start is called before the first frame update
    void Start()
    {
        if (doorLight == null) doorLight = GetComponentInChildren<Light>();
        if (doorAudio == null) doorAudio = GetComponent<AudioSource>();
        if (audioScript == null) audioScript = FindObjectOfType<PAP_Audio>();
        if (lightScript == null) lightScript = FindObjectOfType<PAP_Light>();
    }

    // Update is called once per frame
    void Update()
    {
        doorLight.intensity = brightness;
        doorAudio.volume = volume;

        if (doorPlaying && !safe)
        {
            volume += Time.deltaTime / 50; //slowly increase volume and brightness
            brightness += Time.deltaTime;
            if (!doorAudio.isPlaying)
            {
                doorAudio.Play();
            }
            if (rnd == 0) lightScript.policeLight(doorLight);
            else if (rnd == 1) doorLight.color = Color.yellow;
            else if (rnd == 2) lightScript.policeLight(doorLight, Color.blue, Color.green, 2);
            else doorLight.color = Color.black;
            

        }
        if (!doorPlaying)
        {
            doorAudio.Pause();
        }
    }

    public void resetDoorEffect()
    {
        brightness = 0;
        volume = 0;
    }

    public void newDoorAudio()
    {
        int rnd = Random.Range(0, audioScript.doorAudioList.Count - 1);
        doorAudio.clip = audioScript.doorAudioList[rnd];
        Debug.Log("New audio clip assigned to: " + this.name + "/n Clip: " +  doorAudio.clip);
    }

    public void newDoorLight()
    {
        rnd = Random.Range(0, 4);
        Debug.Log("New Light assigned to: " + this.name + "/n Colour: " + doorLight.color);
    }
}
