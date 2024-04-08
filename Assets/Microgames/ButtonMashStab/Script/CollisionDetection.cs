using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
  
        if (collision.gameObject.GetComponent<KnifeMovement>())
        {
            Debug.Log("Collision with obstacle detected!");

            EventManager.current.GuardStab();
        }
    }

    void GuardDamage()
    {

    }
}
