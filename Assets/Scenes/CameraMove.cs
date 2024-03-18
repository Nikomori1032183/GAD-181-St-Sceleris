using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Vector3 originPoint = new Vector3(0, 52, 0);
    [SerializeField] float moveSpeed;
    [SerializeField] private Vector3[] cameraPositions = new Vector3[6];
    [SerializeField] private EventManager.SelectableClasses cameraMove;
    private bool isAtOrigin = false;
    void Start()
    {
        EventManager.current.onClassSelect += ClassCameraPosition;
    }

    // Update is called once per frame
    void Update()
    {
            switch (cameraMove)
            {

                case EventManager.SelectableClasses.Explosives:
                StartCoroutine(CameraMovement(0));
                break;

                case EventManager.SelectableClasses.Weapons:
                StartCoroutine(CameraMovement(1));
                break;

                case EventManager.SelectableClasses.Stealth:
                StartCoroutine(CameraMovement(2));
                break;

                case EventManager.SelectableClasses.Theft:
                StartCoroutine(CameraMovement(3));
                break;

                case EventManager.SelectableClasses.Planning:
                StartCoroutine(CameraMovement(4));
                break;

                case EventManager.SelectableClasses.Escape:
                StartCoroutine(CameraMovement(5));
                break;
            }
    }
    void ClassCameraPosition(EventManager.SelectableClasses className)
    {
        cameraMove = className; 
    }
    void CameraMovement(int index)
    {

        //if (transform.position == originPoint)
        //{
        //    isAtOrigin = true;
        //}
        if (transform.position == originPoint)
        {
            isAtOrigin = true;
        }

        else if (transform.position == cameraPositions[index])
        {
            isAtOrigin = false;
        }

        if (isAtOrigin)
        {
            transform.position = Vector3.MoveTowards(transform.position, cameraPositions[index], moveSpeed * Time.deltaTime); // Go to pos
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, originPoint, moveSpeed * Time.deltaTime); // Return to origin
        }

        yield return null;
        //if (isIn)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, cameraPositions[index], moveSpeed * Time.deltaTime); // Go to pos
        //    yield return new WaitForSeconds(2);
        //    transform.position = Vector3.MoveTowards(transform.position, originPoint, moveSpeed * Time.deltaTime); // Return to origin
        //    yield return new WaitForSeconds(2);
        //    isIn = false;
        //}
    }
}
