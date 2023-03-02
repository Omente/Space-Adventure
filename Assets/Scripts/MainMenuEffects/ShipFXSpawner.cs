using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFXSpawner : MonoBehaviour
{
    [SerializeField] private float minSpawnTime, maxSpawnTime;
    [SerializeField] private GameObject[] ships;
    [SerializeField] private GameObject objectPool;
    [SerializeField] private Transform[] spawnPoints;

    private bool shipSpawned;
    private int numShipsToSpawn;
    private float spawnTimer;
    private List<GameObject> spawnList = new List<GameObject>();

    private void Start()
    {
        spawnTimer = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
        spawnList.Clear();
    }

    private void Update()
    {
        if (Time.time > spawnTimer) SpawnShips();
    }

    private void SpawnShips()
    {
        numShipsToSpawn = Random.Range(0, 3);


        for (int i = 0; i < numShipsToSpawn; i++)
        {
            shipSpawned = false;

            for (int j = 0; j < spawnList.Count; j++)
            {
                if (!spawnList[j].activeInHierarchy)
                {
                    spawnList[j].SetActive(true);
                    spawnList[j].transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                    shipSpawned = true;
                    break;                        
                }
            }

            if(!shipSpawned)
            {
                GameObject instance = Instantiate(ships[Random.Range(0, ships.Length)], 
                    spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
                instance.transform.SetParent(objectPool.transform);
                spawnList.Add(instance);
            }
        }

        spawnTimer = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }
}
