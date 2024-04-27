using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using VInspector;

public class GrabTheCash : Microgame
{
    // References
    [SerializeField] GameObject moneyPilePrefab;
    [SerializeField] GameObject spawnArea;

    // Variables
    [SerializeField] private int moneyPiles;

    public int moneyCollected;

    override protected void Start()
    {
        base.Start();

        EventManager.current.onCashCollected += CollectMoney;

        moneyCollected = 0;

        Debug.Log("money collected: " + moneyCollected);
        Debug.Log("money piles: " + moneyPiles);
    }

    private void OnDestroy()
    {
        EventManager.current.onCashCollected -= CollectMoney;
    }

    override protected void PlayMicrogame()
    {
        base.PlayMicrogame();

        SpawnMoney();
    }

    override protected void StopMicrogame()
    {
        base.StopMicrogame();
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
    private void SpawnMoney()
    {
        for (int i = 0; i < moneyPiles; i++)
        {
            SpawnPile();
        }
    }

    private void SpawnPile()
    {
        Vector3 spawnPos = new Vector3(Random.Range(SpawnAreaPositions()[0].x, SpawnAreaPositions()[1].x), 0, Random.Range(SpawnAreaPositions()[0].z, SpawnAreaPositions()[1].z));
        Quaternion rotation = new Quaternion(moneyPilePrefab.transform.rotation.x + Random.Range(0, 361), moneyPilePrefab.transform.rotation.y + Random.Range(0, 361), moneyPilePrefab.transform.rotation.z + Random.Range(0, 361), moneyPilePrefab.transform.rotation.w);

        Instantiate(moneyPilePrefab, spawnPos, rotation);
    }

    [Button]
    private void ClearMoney()
    {
        Object[] objectsToClear = FindObjectsOfType<MoneyPile>();

        foreach (Object obj in objectsToClear)
        {
            DestroyImmediate(obj.GameObject());
        }
    }

    private void CollectMoney()
    {
        moneyCollected++;

        Debug.Log("Money Collected: " + moneyCollected);

        if (moneyCollected >= moneyPiles)
        {
            result = true;

            Debug.Log("All Money Collected (Win)");

            StopMicrogame();
        }
    }
}