using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectPositions : MonoBehaviour
{
    //need to have: Correct location, collider, sense collision

    [SerializeField] GameObject mineObject;
    [SerializeField] AudioSource clipSound;
    //[SerializeField] String mineName;
    //Collider myCollider;
    Rigidbody objectsRB;

    public bool inPos = false;

    private void Start()
    {
        //myCollider = GetComponent<Collider>();
        objectsRB = mineObject.GetComponent<Rigidbody>();
        mineObject.transform.position = Vector3.zero;
    }

    void OnTriggerEnter(Collider thineCollision)
    {
        Debug.Log("collision detected");
        if (thineCollision.gameObject.name == mineObject.gameObject.name + "(Clone)")
        {
            Debug.Log("hit correct position");
            //mineObject.transform.position = this.transform.position;
            objectsRB.constraints = RigidbodyConstraints.FreezeAll;
            thineCollision.gameObject.transform.position = this.transform.position;
            thineCollision.gameObject.transform.rotation = this.transform.rotation;
            Destroy(thineCollision.GetComponent<Draggable>());

            inPos = true;
            EventManager.current.PieceCorrect();

            //Play sound
            clipSound.Play();
        }
    }
}
