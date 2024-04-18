using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private void OnMouseDrag()
    {
        if (InputManager.current.GetControlsActive())
        {
            Drag();
        }
    }

    void Drag()
    {
        Vector3 mousePosition = new Vector3(InputManager.current.GetMousePosition().x, 0, InputManager.current.GetMousePosition().z);

        transform.position = mousePosition;

        //transform.position = Vector3.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
    }
}
