using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using VInspector;

public class HideTheContraband : Microgame
{
    // References
    [SerializeField] GameObject contrabandPrefab1, contrabandPrefab2, contrabandPrefab3;
    [SerializeField] GameObject spawnArea;

    // Variables
    [SerializeField] private int contrabandAmount;

    int contrabandCollected = 0;

    override protected void Start()
    {
        base.Start();

        EventManager.current.onContrabandStashed += StashContraband;

        SpawnContrabands();
    }

    override protected void PlayMicrogame()
    {
        base.PlayMicrogame();
    }

    override protected void StopMicrogame()
    {
        base.StopMicrogame();
    }

    private void Update()
    {

    }

    private Vector3[] SpawnAreaPositions()
    {
        Vector3[] spawnPositions = new Vector3[2];
        Transform spawnAreaTransform = spawnArea.transform;

        spawnPositions[0] = new Vector3(spawnAreaTransform.position.x + (spawnAreaTransform.localScale.x / 2), 0, spawnAreaTransform.position.z + (spawnAreaTransform.localScale.z / 2));
        spawnPositions[1] = new Vector3(spawnAreaTransform.position.x - (spawnAreaTransform.localScale.x / 2), 0, spawnAreaTransform.position.z - (spawnAreaTransform.localScale.z / 2));

        return spawnPositions;
    }

    [Button]
    private void SpawnContrabands()
    {
        for (int i = 0; i < contrabandAmount; i++)
        {
            SpawnContraband();
        }
    }

    private void SpawnContraband()
    {
        Vector3 spawnPos = new Vector3(Random.Range(SpawnAreaPositions()[0].x, SpawnAreaPositions()[1].x), 0, Random.Range(SpawnAreaPositions()[0].z, SpawnAreaPositions()[1].z));
        GameObject contrabandPrefab;

        switch (Random.Range(0, 3))
        {
            case 0:
                contrabandPrefab = contrabandPrefab1;
                break;

            case 1:
                contrabandPrefab = contrabandPrefab2;
                break;

            case 2:
                contrabandPrefab = contrabandPrefab3;
                break;

            default:
                contrabandPrefab = contrabandPrefab1;
                break;
        }

        Quaternion rotation = new Quaternion(contrabandPrefab.transform.rotation.x + Random.Range(0, 361), contrabandPrefab.transform.rotation.y + Random.Range(0, 361), contrabandPrefab.transform.rotation.z + Random.Range(0, 361), contrabandPrefab.transform.rotation.w);
        Instantiate(contrabandPrefab, spawnPos, rotation);
    }

    [Button]
    private void ClearContraband()
    {
        Object[] objectsToClear = FindObjectsOfType<Contraband>();

        foreach (Object obj in objectsToClear)
        {
            DestroyImmediate(obj.GameObject());
        }
    }

    private void StashContraband()
    {
        contrabandCollected++;

        //Debug.Log("Contraband Stashed: " + contrabandCollected);

        if (contrabandCollected >= contrabandAmount)
        {
            result = true;

            Debug.Log("All Contraband Stashed (Win)");

            StopMicrogame();
        }
    }
}