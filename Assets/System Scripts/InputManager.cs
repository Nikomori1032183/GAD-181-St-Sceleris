using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager current;

    private bool controlsActive = true;

    private Vector3 mousePosition;

    private void Awake()
    {
        current = this;
    }

    private void Update()
    {
        // Left Click
        if (Input.GetMouseButton(0))
        {
            LeftClick();
        }

        // Left Click Down
        if (Input.GetMouseButtonDown(0))
        {
            LeftClickUp();
        }

        // Left Click Up
        if (Input.GetMouseButtonUp(0))
        {
            LeftClickDown();
        }

        // Mouse Position
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, (Input.mousePosition.y), Camera.main.transform.position.y));
    }

    // Input Events
    public event Action onLeftClick;
    public void LeftClick()
    {
        if (onLeftClick != null && controlsActive)
        {
            onLeftClick();
        }
    }

    public event Action onLeftClickUp;
    public void LeftClickUp()
    {
        if (onLeftClickUp != null && controlsActive)
        {
            onLeftClickUp();
        }
    }

    public event Action onLeftClickDown;
    public void LeftClickDown()
    {
        if (onLeftClickDown != null && controlsActive)
        {
            onLeftClickDown();
        }
    }

    public Vector3 GetMousePosition()
    {
        return mousePosition;
    }

    public void SetControlsActive(bool state)
    {
        controlsActive = state;
        
        Debug.Log("Controls Active Set To: " + controlsActive);
    }

    public bool GetControlsActive()
    {
        return controlsActive;
    }
}