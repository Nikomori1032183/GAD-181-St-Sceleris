using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GTTE_Spot : MonoBehaviour
{
    float speed = 0.003f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GTTE_Main.GTTEPlaying)
        {
            transform.position -= new Vector3(Time.time * speed, 0, 0);
        }
        if(transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            Debug.Log("Player Triggered Alarm");
            GTTE_Main.GTTENoticed = true;
        }
    }
}
