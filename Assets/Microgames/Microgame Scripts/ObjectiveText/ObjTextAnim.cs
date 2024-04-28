using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class ObjTextAnim : MonoBehaviour
{
    [SerializeField] private Sprite objText;
    [SerializeField] private GameObject anchor;
    [SerializeField] private int timeToWait = 2; //set to 2 seconds by default
    private GameObject _anchor;
    private GameObject UICanvasRef;
    [SerializeField] bool showAnimation;
    [SerializeField] bool finishAnimation;

    //Two vector 3 refs for just below the screen, and the centre of the screen.
    private Vector3 screenStart = new Vector3(Screen.width * 0.5f, (Screen.height - Screen.height - 100), 0);
    private Vector3 screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
    void Start()
    {
        UICanvasRef = GameObject.FindWithTag("UICanvas");
        EventManager.current.onDisplayObjective += DisplayObjective;
        //EventManager.current.onHideObjective += HideObjective;
    }

    // Update is called once per frame
    void Update()
    {
        if (showAnimation)
        {
            StartCoroutine(PlayAnimation());
        }
    }
    [Button]
    private void DisplayObjective()
    {
        //Spawns the UI object anchor as a child of the Canvas, then spawns the Objective text as a sprite > as a child of the anchor
        _anchor = Instantiate(anchor, screenStart, Quaternion.identity, UICanvasRef.transform);
        Instantiate(objText, screenStart, Quaternion.identity, _anchor.transform);
        showAnimation = true;

    }
    IEnumerator PlayAnimation()
    {
        if (anchor.transform.position != screenCenter)
        {
            anchor.transform.position = Vector3.MoveTowards(anchor.transform.position, screenCenter, 40 * Time.deltaTime);
        }
        else if (anchor.transform.position == screenCenter)
        {
            yield return new WaitForSecondsRealtime(timeToWait);
            anchor.transform.position = Vector3.MoveTowards(anchor.transform.position, screenStart, 40 * Time.deltaTime);
            finishAnimation = true;
        }
        if (finishAnimation)
        {
            Destroy(objText);
            Destroy(anchor);
        }
                
    }
}
