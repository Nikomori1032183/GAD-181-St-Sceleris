using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTester : MonoBehaviour
{
    public GameObject testObject;
    public float zPos = 0f;
    public Vector3 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       mousePosition = InputManager.current.GetMousePosition(); 
       Debug.Log(InputManager.current.GetMousePosition());
       mousePosition = new Vector3(mousePosition.x, mousePosition.y, mousePosition.z);
       testObject.transform.position = mousePosition;
    }
}
