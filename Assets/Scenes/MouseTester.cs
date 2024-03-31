using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTester : MonoBehaviour
{
    public GameObject testObject;
    public Vector3 mousePosition;
    public Vector3 hitPoint;
    public float maxDist = 10f;
    public float speed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
        CastToPoint();
    }
    void MoveObject()
    {
        mousePosition = InputManager.current.GetMousePosition();
        testObject.transform.position = Vector3.MoveTowards(testObject.transform.position, hitPoint, speed * Time.deltaTime);
    }
    void CastToPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDist))
        {
            hitPoint = hit.point;
        }
        else
        {
            hitPoint = (ray.origin + ray.direction * 10);
        }
        Debug.DrawLine(ray.origin, hit.point, Color.red);
        hitPoint = hit.point;
    }
}
