using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using VInspector;

public class ObjectiveTextAnimation : MonoBehaviour
{
    [SerializeField] private Sprite objectiveImage;
    [SerializeField] private Object objectivePrefab;
    [SerializeField] private int moveSpeed = 40;
    [SerializeField] private int timeToWait = 2;
    private Vector3 screenStart = new Vector3(Screen.width * 0.5f, (Screen.height - Screen.height - 100), 0);
    private Vector3 screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
    private bool boolA;
    private bool boolB;
    private bool hasMoved = false;
    private GameObject activeObjective;
    // Start is called before the first frame update
    void Start()
    {
        //EventManager.current.onDisplayObjective += DisplayObjective;
        activeObjective = Instantiate(objectivePrefab, screenStart, Quaternion.identity, GetComponentInParent<Transform>()) as GameObject;
    }
    void Update()
    {
        if (boolA)
        {
            iDisplayObjective();
        }
        if (boolB)
        {
            iHideObjective();
        }
    }
    void iDisplayObjective()
    {
        if (!hasMoved && activeObjective.transform.position != screenCenter)
        {
            activeObjective.transform.position = Vector3.MoveTowards(activeObjective.transform.position, screenCenter, moveSpeed * Time.deltaTime);
        }
        if (!hasMoved && activeObjective.transform.position == screenCenter)
        {

            hasMoved = true;
        }
    }
    void iHideObjective()
    {
        if (hasMoved)
        {
            activeObjective.transform.position = Vector3.MoveTowards(activeObjective.transform.position, screenStart, moveSpeed * Time.deltaTime);
        }
        if (hasMoved && activeObjective.transform.position == screenStart)
        {
            Destroy(this.gameObject);
        }
    }
    [Button]
    void DisplayObjective()
    {
        boolA = true;
        boolB = false;
    }
    [Button]
    void HideObjective()
    {
        boolB = true;
        boolA = false;
    }
}