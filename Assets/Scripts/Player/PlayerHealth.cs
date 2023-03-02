using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float playetMaxHealth;
    [SerializeField] private GameObject playerExplosionFX;
    [SerializeField] private GameObject playerDamageFX;

    private float playerHealth;
    private Collectable collectable;
    private Slider playerHealthSlider;

    private void Awake()
    {
        playerHealth = playetMaxHealth;

        playerHealthSlider = GameObject.FindWithTag(TagManager.PLAYER_HEALTH_SLIDER_TAG).GetComponent<Slider>();
        playerHealthSlider.minValue = 0;
        playerHealthSlider.maxValue = playerHealth;
        playerHealthSlider.value = playerHealth;
    }

    public void TakeDamage(float damageAmmount)
    {
        playerHealth -= damageAmmount;

        playerHealthSlider.value = playerHealth;

        if(playerHealth <= 0f)
        {
            SoundManager.instance.PlayDestroySound();

            Instantiate(playerExplosionFX, transform.position, Quaternion.identity);
            
            GameOverUIController.instance.OpenGameOverPanel();
            
            Destroy(gameObject);

        }
        else
        {
            SoundManager.instance.PlayDamageSound();
            
            Instantiate(playerDamageFX, transform.position, Quaternion.identity);
        }

        SetHealthBar();
    }

    private void SetHealthBar()
    {
        return;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag(TagManager.METEOR_TAG))
        {
            TakeDamage(Random.Range(20, 40));
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag(TagManager.COLLECTABLE_TAG))
        {
            collectable = collision.gameObject.GetComponent<Collectable>();

            if(collectable.Type == CollectableType.Health)
            {
                playerHealth += collectable.HealthValue;

                playerHealthSlider.value = playerHealth;

                if(playerHealth > playetMaxHealth)
                    playerHealth = playetMaxHealth;

                Destroy(collision.gameObject);
            }
        }
    }
}