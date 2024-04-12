using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PAP_Toggle : MonoBehaviour
{
    public Light spotLight;
    Toggle toggle;
    public PAP_Door door;

    BaseEventData eventData;

    // Start is called before the first frame update
    void Start()
    {
        if (toggle == null) toggle = GetComponent<Toggle>();
        if (spotLight == null) spotLight = GetComponentInChildren<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        //renaming door and toggle to only require toggle
    }

    public void Selected()
    {
        spotLight.enabled = spotLight.enabled = true;
        door.doorPlaying = true;
        //Debug.Log(this.name + " has been Selected");
        if (PAP_Main.currentDoor != door)
        {
            PAP_Main.currentDoor = this;
        }
    }

    public void Deselect()
    {
        spotLight.enabled = spotLight.enabled = false;
        door.doorPlaying = false;
    }



}
