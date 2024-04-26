using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;
using VInspector;

public class KnifeMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject guard;

    bool stabbing;
    bool returning;
    private bool isMouseDown = false;

    private void Start()
    {
        EventManager.current.onGuardStab += GuardStabbed;
    }

    void Update()
    {
        if (transform.position == Vector3.zero)
        {
            returning = false;
        }

        Movement();


    }

    void Movement()
    {
        if (stabbing)
        {
            transform.position = Vector3.MoveTowards(transform.position, guard.transform.position, moveSpeed * Time.deltaTime);
        }
        
        else if (returning)
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, moveSpeed * Time.deltaTime);
        }
    }

    public void SetReturning(bool returning)
    {
        this.returning = returning;
    }
    public bool GetReturning()
    {
        return returning;
    }

    public void SetStabbing(bool stabbing)
    {
        this.stabbing = stabbing;
    }

    public bool GetStabbing()
    {
        return stabbing;
    }

    void GuardStabbed()
    {
        SetStabbing(false);
    }

}

