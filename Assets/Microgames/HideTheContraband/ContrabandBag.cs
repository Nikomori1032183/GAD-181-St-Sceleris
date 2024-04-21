using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrabandBag : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ContrabandBag>() != null)
        {
            //Debug.Log("Money Pile Entered Bag Trigger");

            Destroy(other.gameObject);

            EventManager.current.ContrabandStashed();
        }
    }
}
