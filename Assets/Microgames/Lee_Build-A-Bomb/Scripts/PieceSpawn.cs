using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawn : MonoBehaviour
{
    [SerializeField] List<GameObject> objectParts, spawnPoints;

    private void Start()
    {
        
        if(objectParts.Count > spawnPoints.Count)
        {
            Debug.Log("More Parts than Spawn Points, Can Not Spawn");
            return;
        }
        for(int i = 0; i < objectParts.Count; i++)
        {
            GameObject currentPart = Instantiate(objectParts[i], spawnPoints[i].transform);
        }
    }
}
