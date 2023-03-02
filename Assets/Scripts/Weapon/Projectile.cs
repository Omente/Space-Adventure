using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float minDamage = 10f;
    public float MinDamage { get { return minDamage; } }
    [SerializeField] private float maxDamage = 30f;
    public float MaxDamage { get { return maxDamage; } }
    [SerializeField] private AudioClip spawnSound;
    [SerializeField] private GameObject boomEffect;
    [SerializeField] private AudioClip destroySound;

    private float projectileDamage;

    private void OnEnable()
    {
        projectileDamage = (int)Random.Range(minDamage, maxDamage);

        if (spawnSound) AudioSource.PlayClipAtPoint(spawnSound, new Vector3(0f, 0f, 0f));
    }

    private void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(TagManager.PLAYER_TAG))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(projectileDamage);
        }

        if (collision.gameObject.CompareTag(TagManager.ENEMY_TAG) || collision.gameObject.CompareTag(TagManager.METEOR_TAG))
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(projectileDamage, 0f);
        }

        if (!collision.gameObject.CompareTag(TagManager.UNTAGGED_TAG) && !collision.gameObject.CompareTag(TagManager.COLLECTABLE_TAG))
        {
            gameObject.SetActive(false);
        }
    }
}
