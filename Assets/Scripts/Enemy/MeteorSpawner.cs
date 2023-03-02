using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private float minX, maxX;
    [SerializeField] private GameObject[] meteors;

    private float minSpawnInterval = 4f, maxSpawnInterval = 10f;
    private float spawnInterval;
    private int randSpawnNum;
    private Vector3 randSpawnPos;

    private void Start()
    {
        spawnInterval = Time.time;
    }

    private void Update()
    {
        SpawnMeteors();
    }

    private void SpawnMeteors()
    {
        if (Time.time < spawnInterval) return;
        randSpawnNum = Random.Range(0, meteors.Length);

        for (int i = 0; i < randSpawnNum; i++)
        {
            randSpawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);
            Instantiate(meteors[Random.Range(0, meteors.Length)], randSpawnPos, Quaternion.identity);
        }

        spawnInterval = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
    }

} 
