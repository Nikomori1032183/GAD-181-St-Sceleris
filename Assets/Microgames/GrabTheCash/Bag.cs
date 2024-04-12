using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Bag Trigger Entered");

        if (other.GetComponent<MoneyPile>() != null)
        {
            //Debug.Log("Money Pile Entered Bag Trigger");

            Destroy(other.gameObject);

            EventManager.current.CashCollected();
        }
    }
}