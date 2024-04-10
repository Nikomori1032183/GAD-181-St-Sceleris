using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColourOnClick : MonoBehaviour
{
    public Color newColor = Color.red; // New color to apply when clicked

    private void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits this game object
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                // Change the color of the game object
                Renderer renderer = GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = newColor;
                }
            }
        }
    }
}
