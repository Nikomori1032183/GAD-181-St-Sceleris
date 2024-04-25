using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField] float yAxis;
    private void OnMouseDrag()
    {
        if (InputManager.current.GetControlsActive())
        {
            Drag(yAxis);
        }
    }

    void Drag(float yAxis)
    {
        Vector3 mousePosition = new Vector3(InputManager.current.GetMousePosition().x, yAxis, InputManager.current.GetMousePosition().z);

        transform.position = mousePosition;

        //transform.position = Vector3.MoveTowards(transform.position, mousePosition, speed * Time.deltaTime);
    }
}
