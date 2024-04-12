using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.EventSystems;

public class GTTE_Player : MonoBehaviour
{
    //FIX: Falling after jump

    Rigidbody rb;

    public float thrust = 5f;
    private Vector3 jumpValue = new Vector3(0, 4f, 0);

    float jumpHeight = 8f;
    float timeToReachApex = 2f;
    float gravity;
    float jumpVelocity;

    bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        //InputManager.current.onLeftClick += doJump();
        if (rb == null) rb = GetComponent<Rigidbody>();
        gravity = 2f * jumpHeight / (timeToReachApex * timeToReachApex);
        jumpVelocity = gravity * timeToReachApex;

        InputManager.current.onLeftClick += Jump;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded && GTTE_Main.GTTEPlaying)
        {
            Jump();
        }

        if (rb.velocity.y <= 0)
        {
            rb.AddForce(transform.up * -thrust, ForceMode.Impulse);
        }
        */
    }

    private void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void Jump()
    {
        if (isGrounded && GTTE_Main.GTTEPlaying)
        {
            isGrounded = false;
            Debug.Log("Jump");
            rb.AddForce(jumpValue * thrust, ForceMode.Impulse);
            //this.transform.position = new Vector3(transform.position.x, jumpVelocity, transform.position.z);
        }
    }
}
