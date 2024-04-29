using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPick : Microgame
{
    public Camera cam;
    public Transform innerLock;
    public Transform pickPosition;
    public float maxAngle = 90; //setting 90 degree lock
    public float lockSpeed = 10;

    [Range(1, 25)]
    public float lockRange = 10;
    private float eulerAngle;//current angle which locks at
    private float unlockAngle;
    private Vector2 unlockRange;

    private float keyPressTime = 0;

    private bool movePick = true;

    // Start is called before the first frame update
    protected override void Start()
    {
       base.Start();
       newLock();
       Debug.Log("Lock Pick Microgame started");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition = pickPosition.position;//lock pin pos

        //if (movePick)
        //{
        //    //Vector3 dir = Input.mousePosition - cam.WorldToScreenPoint(transform.position);

        //    eulerAngle = Vector3.Angle(dir, Vector3.up);//axis it will rotate around

        //    Vector3 cross = Vector3.Cross(Vector3.up, dir);
        //    if (cross.z < 0)
        //    {
        //        eulerAngle = -eulerAngle;
        //    }

        //    eulerAngle = Mathf.Clamp(eulerAngle, -maxAngle, maxAngle);//bounds

        //    Quaternion rotateTo = Quaternion.AngleAxis(eulerAngle, Vector3.forward);
        //    transform.rotation = rotateTo;
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    movePick = false;
        //    keyPressTime = 1;
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    movePick = true;
        //    keyPressTime = 0;
        //}

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    StopMicrogame();
        //}

        //float percentage = Mathf.Round(100 - Mathf.Abs(((eulerAngle - unlockAngle) / 100) * 100));
        //float lockRotation = ((percentage / 100) * maxAngle) * keyPressTime;
        //float maxRotation = (percentage / 100) * maxAngle;

        //float lockLerp = Mathf.Lerp(innerLock.eulerAngles.z, lockRotation, Time.deltaTime * lockSpeed);
        //innerLock.eulerAngles = new Vector3(0, 0, lockLerp);

        //if (lockLerp >= maxRotation - 1)
        //{
        //    if (eulerAngle < unlockRange.y && eulerAngle > unlockRange.x)
        //    {
        //        Debug.Log("Lock is unlocked!"); //win log
        //        newLock();
        //        movePick = true;
        //        keyPressTime = 0;
        //        result = true;

        //        StopMicrogame();

        //    }
        //    else
        //    {
        //        float randomRotation = Random.insideUnitCircle.x;
        //        transform.eulerAngles += new Vector3(0, 0, Random.Range(-randomRotation, randomRotation));

        //        result = false;
        //    }
           
        //}
    }

    void newLock()
    {
        unlockAngle = Random.Range(-maxAngle + lockRange, maxAngle - lockRange);
        unlockRange = new Vector2(unlockAngle - lockRange, unlockAngle + lockRange);
        Debug.Log("Unlock Angle: " + unlockAngle);
    }

    protected override void PlayMicrogame()
    {
        base.PlayMicrogame();
        newLock();  


    }

    protected override void StopMicrogame()
    {
        base.StopMicrogame();
    }

}


