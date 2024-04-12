using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LT_Player_SU : MonoBehaviour
{
    
    private Rigidbody rb;
    public static AudioSource audioSource;

    public static bool inPlay = false;
    public bool leftOn = false;
    public bool rightOn = false;


    // Start is called before the first frame update
    void Start()
    {
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.2f, 4.2f), transform.position.y, 0f);

        if (inPlay == false)
        {
            rb.useGravity = false;
            rb.velocity = new Vector3(rb.velocity.x, 0f, 0f);
        }
        
        if (inPlay == true)
        {
            rb.useGravity = true;
            rb.velocity = new Vector3(rb.velocity.x, -1f, 0f);
            if (leftOn)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(-4.2f, transform.position.y, 0f), 0.01f);
            }
            if (rightOn)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(4.2f, transform.position.y, 0f), 0.01f);
            }
        }
    }

    public void onLeft(bool on)
    {
        leftOn = on;
    }

    public void onRight(bool on)
    {
        rightOn = on;
    }
}
