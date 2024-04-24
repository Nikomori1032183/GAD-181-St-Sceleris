using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColourOnClick : MonoBehaviour
{
    public Color newColor = Color.red;

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
               
                Renderer renderer = GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = newColor;
                }
            }
        }
    }
}
