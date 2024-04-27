using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager current;

    [SerializeField] private bool controlsActive = true;

    private Vector3 mousePosition;

    private void Awake()
    {
        current = this;
    }

    private void Update()
    {

        // Left Click Down
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            LeftClickDown();
        }

        // Left Click
        if (Input.GetKey(KeyCode.Mouse0))
        {
            LeftClick();
        }

        // Left Click Up
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            LeftClickUp();
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