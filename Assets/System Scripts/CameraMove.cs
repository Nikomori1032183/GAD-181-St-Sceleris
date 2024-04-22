using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VInspector;

public class CameraMove : MonoBehaviour
{
    /// <summary>
    /// Will change the camera position to sit above the class when activated. Moves from it's current position to the predetermined camera
    /// position for the classroom. All adjustable. Will move Current Position -> Origin Position -> New position.
    /// </summary>
    // Start is called before the first frame update
    [SerializeField] private Vector3 originPoint = new Vector3(0, 52, 0);
    [SerializeField] float moveSpeed;
    [SerializeField] private Vector3[] cameraPositions = new Vector3[6];
    [SerializeField] private GameObject schoolObject;
    [SerializeField] private EventManager.SelectableClasses cameraMove;
    private bool isAtOrigin = false;
    private bool running = false;
    
    //Awake because load order is incorrect from scene heirarchy. Ensures it loads properly if heirarchy is not consistent. Remember this for other errors.
    void Start()
    {

        EventManager.current.onClassSelect += ClassCameraPosition;
        EventManager.current.onLevelSelectLoaded += SetSchoolModel;
    }


    //Switch case controlls where the camera moves to. Array of Vector3's is indexed for the specific locations.
    void Update()
    {

        if (running)
        {
            switch (cameraMove)
            {
                case EventManager.SelectableClasses.Explosives:
                    CameraMovement(0);
                    break;

                case EventManager.SelectableClasses.Weapons:
                    CameraMovement(1);
                    break;

                case EventManager.SelectableClasses.Stealth:
                    Debug.Log(cameraMove);
                    CameraMovement(2);
                    break;

                case EventManager.SelectableClasses.Theft:
                    CameraMovement(3);
                    break;

                case EventManager.SelectableClasses.Planning:
                    CameraMovement(4);
                    break;

                case EventManager.SelectableClasses.Escape:
                    CameraMovement(5);
                    break;
            }
        }
    }

    void SetSchoolModel(Scene levelSelectScene)
    {
        StartCoroutine(DelayLookForSchool());        
    }

    void ClassCameraPosition(EventManager.SelectableClasses className)
    {
        running = true;
        cameraMove = className; 
    }

    //Camera movement checks if it is at the origin point before moving.
    void CameraMovement(int index)
    {
        if (schoolObject.transform.position == originPoint)
        {
            isAtOrigin = true;
        }

        else if (schoolObject.transform.position == cameraPositions[index])
        {
            isAtOrigin = false;
            running = false;
        }

        if (isAtOrigin)
        {
            schoolObject.transform.position = Vector3.MoveTowards(schoolObject.transform.position, cameraPositions[index], moveSpeed * Time.deltaTime); // Go to pos
        }
        else
        {
            schoolObject.transform.position = Vector3.MoveTowards(schoolObject.transform.position, originPoint, moveSpeed * Time.deltaTime); // Return to origin
        }
    }
    [Button]
    void CameraReturnToOrigin()
    {
        schoolObject.transform.position = Vector3.MoveTowards(schoolObject.transform.position, originPoint, moveSpeed * Time.deltaTime);
    }
    IEnumerator DelayLookForSchool()
    {
        yield return new WaitForSeconds(0.1f);
        schoolObject = GameObject.FindWithTag("SchoolModel");
    }
}
