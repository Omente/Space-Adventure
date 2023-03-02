using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFXSpawner : MonoBehaviour
{
    [SerializeField] private float minSpawnTime = 4f, maxSpawnTime = 10f;
    [SerializeField] private GameObject[] meteors;
    [SerializeField] private GameObject objectsPool;
    [SerializeField] private Transform[] spawnPoints;

    private bool meteorSpawned;
    private int numMeteorsToSpawn;
    private float spawnTimer;
    private List<GameObject> spawnList = new List<GameObject>();

    private void Start()
    {
        spawnTimer = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
        spawnList.Clear();
    }

    private void Update()
    {
        if (Time.time > spawnTimer) SpawnMeteor();
    }

    private void SpawnMeteor()
    {
        numMeteorsToSpawn = Random.Range(0, 6);

        for (int i = 0; i < numMeteorsToSpawn; i++)
        {
            meteorSpawned = false;

            for (int j = 0; j < spawnList.Count; j++)
            {
                if (!spawnList[j].activeInHierarchy)
                {
                    spawnList[j].SetActive(true);
                    spawnList[j].transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                    meteorSpawned = true;
                    break;
                }
            }

            if(!meteorSpawned)
            {
                GameObject instance = Instantiate(meteors[Random.Range(0, meteors.Length)], 
                    spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
                instance.transform.SetParent(objectsPool.transform);
                spawnList.Add(instance);
            }
        }

        spawnTimer = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }

}
