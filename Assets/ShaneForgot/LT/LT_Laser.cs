using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LT_Laser : MonoBehaviour
{
    public List<LT_LoseTrigger_SU> laserTriggers;
    [SerializeField] List<LT_LoseTrigger_SU> group0;
    [SerializeField] List<LT_LoseTrigger_SU> group1;
    [SerializeField] List<LT_LoseTrigger_SU> group2;

    public int maxPerGroup = 5;
    bool lasersRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void groupLasers()
    {
        for (int i = 0; i < laserTriggers.Count; i++) //sorts the lasers into random groups of maxPerGroup
        {
            int rnd = Random.Range(0, 3);
            if (rnd == 0)
            {
                if (group0.Count >= maxPerGroup)
                {
                    rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        if (group1.Count >= maxPerGroup) group2.Add(laserTriggers[i]);
                        else group1.Add(laserTriggers[i]);
                    }
                    else if (rnd == 1)
                    {
                        if (group2.Count >= maxPerGroup) group1.Add(laserTriggers[i]);
                        else group2.Add(laserTriggers[i]);
                    }
                }
                else group0.Add(laserTriggers[i]);
                
            }
            else if (rnd == 1)
            {
                if (group1.Count >= maxPerGroup)
                {
                    rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        if (group0.Count >= maxPerGroup) group2.Add(laserTriggers[i]);
                        else group0.Add(laserTriggers[i]);
                    }
                    else if (rnd == 1)
                    {
                        if (group2.Count >= maxPerGroup) group0.Add(laserTriggers[i]);
                        else group2.Add(laserTriggers[i]);
                    }
                }
                else group1.Add(laserTriggers[i]);
            }
            else if (rnd == 2)
            {
                if (group2.Count >= maxPerGroup)
                {
                    rnd = Random.Range(0, 2);
                    if (rnd == 0)
                    {
                        if (group0.Count >= maxPerGroup) group1.Add(laserTriggers[i]);
                        else group0.Add(laserTriggers[i]);
                    }
                    else if (rnd == 1)
                    {
                        if (group1.Count >= maxPerGroup) group0.Add(laserTriggers[i]);
                        else group1.Add(laserTriggers[i]);
                    }
                }
                else group2.Add(laserTriggers[i]);
            }
            //Debug.Log(i + " got " + rnd);
        }
    }

    public void laserOn(bool on)
    {
        //Debug.Log("laserOn");
        StartCoroutine(laserBegin());
        lasersRunning = on;
    }

    void allLasers(List<LT_LoseTrigger_SU> group, bool on)
    {
        foreach (LT_LoseTrigger_SU laserTrigger in group)
        {
            laserTrigger.laser.SetActive(on);
        }
    }

    IEnumerator laserWait(List<LT_LoseTrigger_SU> group)
    {
        //Debug.Log("laserWait");
        StartCoroutine(laserWarning(group));
        StartCoroutine(laserWarning(group));

        allLasers(group, false);
        yield return new WaitForSeconds(4);
        allLasers(group, true);

        if (lasersRunning == true)
        {
            StartCoroutine(laserWait(group));
        }
        //Debug.Log("laserWait finished");
    }

    IEnumerator laserWarning(List<LT_LoseTrigger_SU> group)
    {
        //Debug.Log("laserWarning");
        allLasers(group, false);
        yield return new WaitForSeconds(1);
        allLasers(group, true);
        yield return new WaitForSeconds(1);
        //Debug.Log("laserWarning finished");
    }

    IEnumerator laserBegin()
    {
        //Debug.Log("laserBegin");
        StartCoroutine(laserWait(group0));
        yield return new WaitForSeconds(1);
        StartCoroutine(laserWait(group1));
        yield return new WaitForSeconds(1);
        StartCoroutine(laserWait(group2));
        //Debug.Log("laserBegin finished");
    }
}
