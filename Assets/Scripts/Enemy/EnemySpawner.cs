using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    [SerializeField] private float spawnWaitTime = 2f;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] spawnPoints;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(_SpawnWave(spawnWaitTime));
    }

    private void SpawnNewWaveOfEnemies()
    {
        if (spawnedEnemies.Count > 0) 
            return;

        for(int i = 0; i < spawnPoints.Length; i++)
        {
            int randIndex = Random.Range(0, enemies.Length);

            GameObject newEnemy = Instantiate(enemies[randIndex], spawnPoints[i].position, Quaternion.identity);

            spawnedEnemies.Add(newEnemy);
        }

        GameplayUIController.instance.SetInfo(0);
    }

    IEnumerator _SpawnWave(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SpawnNewWaveOfEnemies();
    }

    public void CheckToSpawnNewWave(GameObject shipToRemove)
    {
        spawnedEnemies.Remove(shipToRemove);

        if (spawnedEnemies.Count < 1) StartCoroutine(_SpawnWave(spawnWaitTime));
    }
}
