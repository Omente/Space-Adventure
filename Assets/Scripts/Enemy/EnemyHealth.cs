using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{ 
    [SerializeField] private float health = 100f;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private GameObject destroyEffect;

    private DropCollectable dropCollectable;
    private Vector3 healthBarSacle;

    private void Start()
    {
        dropCollectable = gameObject.GetComponent<DropCollectable>();
    }

    public void TakeDamage(float damageAmmount, float damageResistance)
    {
        damageAmmount -= damageResistance;
        health -= damageAmmount;

        if (health <= 0)
        {
            health = 0;

            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            SoundManager.instance.PlayDestroySound();

            SetDestroyInfo();

            dropCollectable.SpawnCollectable();

  
            

            Destroy(gameObject);
        }
        else
        {
            SoundManager.instance.PlayDamageSound();
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        SetHealthBar();
    }

    private void SetHealthBar()
    {
        if (!healthBar) return;

        healthBarSacle = healthBar.transform.localScale;
        healthBarSacle.x = health / 100f;
        healthBar.transform.localScale = healthBarSacle;
    }

    private void SetDestroyInfo()
    {
        if (gameObject.CompareTag(TagManager.ENEMY_TAG))
        {
            EnemySpawner.instance.CheckToSpawnNewWave(gameObject);
            GameplayUIController.instance.SetInfo(1);
        }
        else if (gameObject.CompareTag(TagManager.METEOR_TAG))
            GameplayUIController.instance.SetInfo(2);
    }
}
