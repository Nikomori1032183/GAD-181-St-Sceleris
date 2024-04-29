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
    CharacterController charCon;
    public AudioSource playerAudioSource;


    public float thrust = 5f;
    private Vector3 jumpValue = new Vector3(0, 4f, 0);

    float jumpHeight = 8f;
    float timeToReachApex = 2f;
    float gravity;
    float jumpVelocity;

    public bool isGrounded;

    //...................................................//

    public float jumpSpeed;
    float ySpeed;
    float speed;
    bool dblJump = true;

    // Start is called before the first frame update
    void Start()
    {
        //InputManager.current.onLeftClick += doJump();
        if (rb == null) rb = GetComponent<Rigidbody>();
        if (charCon == null) charCon = GetComponent<CharacterController>();
        if (playerAudioSource == null) playerAudioSource = GetComponent<AudioSource>();
        gravity = 2f * jumpHeight / (timeToReachApex * timeToReachApex);
        jumpVelocity = gravity * timeToReachApex;

        //InputManager.current.onLeftClick += Jump;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(0, 0, 0);
        moveDirection.Normalize();
        float magnitude = moveDirection.magnitude;
        magnitude = Mathf.Clamp01(magnitude);
        charCon.SimpleMove(moveDirection * magnitude * speed); //REQUIRED FOR NORMAL JUMPS

        ySpeed += Physics.gravity.y * Time.deltaTime;

        Vector3 vel = moveDirection * magnitude;
        vel.y = ySpeed;
        charCon.Move(vel * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ySpeed = -0.5f;
            isGrounded = true;
            dblJump = true;
        }

        if (charCon.isGrounded)
        {
            ySpeed = -0.5f;
            isGrounded = true;
            dblJump = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isGrounded)
            {
                ySpeed = jumpSpeed;
                isGrounded = false;
            }
            else if(!isGrounded && dblJump)
            {
                Debug.Log("double!");
                ySpeed += jumpSpeed;
                dblJump = false;
            }
            
        }

        
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
