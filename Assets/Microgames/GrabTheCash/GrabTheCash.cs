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
    Vector3[] spawnPositions = new Vector3[2];

    public int moneyCollected;

    override protected void Start()
    {
        base.Start();

        EventManager.current.onCashCollected += CollectMoney;

        moneyCollected = 0;
        SetSpawnAreaPositions();

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

    private void SetSpawnAreaPositions()
    {
        spawnPositions[0] = new Vector3(spawnArea.transform.position.x + (spawnArea.transform.localScale.x / 2), 0, spawnArea.transform.position.z + (spawnArea.transform.localScale.z / 2));
        spawnPositions[1] = new Vector3(spawnArea.transform.position.x - (spawnArea.transform.localScale.x / 2), 0, spawnArea.transform.position.z - (spawnArea.transform.localScale.z / 2));
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
        Vector3 spawnPos = new Vector3(Random.Range(spawnPositions[0].x, spawnPositions[1].x), 0, Random.Range(spawnPositions[0].z, spawnPositions[1].z));
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