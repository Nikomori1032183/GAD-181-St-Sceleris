using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LT_Player_SU : MonoBehaviour
{
    private Camera trackCam;
    private Rigidbody rb;

    bool inPlay = false;

    private Vector3 camPos1 = new Vector3 (0f, 0.61f, -9f);


    // Start is called before the first frame update
    void Start()
    {
        if (trackCam == null)
        {
            trackCam = this.GetComponentInChildren<Camera>();
            Debug.Log("Camera Found");
            trackCam.transform.localPosition = camPos1;
        }
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
        }
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            LTGamePlay();
            inPlay = true;
        }
        if (inPlay == true)
        {
            this.transform.position = new Vector3(Input.mousePosition.x, 0f, 0f); //sets the player to move with the mouse along X
            //clamp ranges
        }
    }

    void LTGamePlay()
    {
        trackCam.transform.rotation = Quaternion.Euler(12.14f, 0f, 0f); //set camera rotation
        //this.transform.position += new Vector3(Input.mousePosition.x, transform.position.y); //sets the player to move with the mouse along X
        //rb.velocity = new Vector3(0f, -1f, 0f);
        //rb.useGravity = true;
        LTLaserStart();
    }

    private void LTLaserStart()
    {
        Debug.Log("Lasers Start");
        //subscription service that all lasers subscripe to begins
    }
}
