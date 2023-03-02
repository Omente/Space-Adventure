using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagerPool : MonoBehaviour
{
    [SerializeField] private bool isEnemy;
    [SerializeField] private float shootWaitTime = 0.2f;    
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private GameObject projectile;
    [SerializeField] private KeyCode keyToPressToShoot;

    private bool projectileSpawned;
    private bool canShoot;
    private float shootTimer;
    private GameObject projectileHolder;
    private List<GameObject> projectilePool = new List<GameObject>();

    private void Awake()
    {
        if (isEnemy)
            projectileHolder = GameObject.FindWithTag(TagManager.ENEMY_PROJECTILE_HOLDER_TAG);
        else
            projectileHolder = GameObject.FindWithTag(TagManager.PLAYER_PROJECTILE_HOLDER_TAG);
    }

    private void Update()
    {
        if (Time.time > shootTimer)
            canShoot = true;

        HandlePlayerShooting();
        HandleEnemyShooting();
    }

    private void HandlePlayerShooting()
    {
        if (!canShoot || isEnemy)
            return;

        if (Input.GetKeyDown(keyToPressToShoot))
        {
            GetObjectPoolOrSpawnANewOne();
            ResetShotingTimer();
        }
    }

    private void HandleEnemyShooting()
    {
        if (!isEnemy || !canShoot)
            return;

        ResetShotingTimer();
        GetObjectPoolOrSpawnANewOne();

    }

    private void GetObjectPoolOrSpawnANewOne()
    {
        for (int i = 0; i < projectilePool.Count; i++)
        {
           if (!projectilePool[i].activeInHierarchy)
            {
                projectilePool[i].transform.position = projectileSpawnPoint.position;
                projectilePool[i].SetActive(true);
                projectileSpawned = true;
                break;
            }
           else projectileSpawned = false;
        }

        if(!projectileSpawned)
        {
            GameObject newProjectileInstance = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);
            newProjectileInstance.transform.SetParent(projectileHolder.transform);
            projectilePool.Add(newProjectileInstance);
            projectileSpawned = true;
        }
    }

    private void ResetShotingTimer()
    {
        canShoot = false;
        if (isEnemy)
            shootTimer = Time.time + Random.Range(shootWaitTime, shootWaitTime + 1f);
        else
            shootTimer = Time.time + shootWaitTime;
    }
}
