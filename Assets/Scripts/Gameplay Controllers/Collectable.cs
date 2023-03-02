using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    Health,
    Blaster1,
    Blaster2,
    Missile,
    Rocket
}

public class Collectable : MonoBehaviour
{
    [SerializeField] private CollectableType type;
    public CollectableType Type { get; set; }
    [SerializeField] private float moveSpeed;

    private float healthValue;
    public float HealthValue{get;}
    private Vector3 tempPos;
    private float minHealth = 10f, maxHealth = 30f;

    private void Awake()
    {
        healthValue = Random.Range(minHealth, maxHealth);

        Type = type;
    }

    private void Update()
    {
        tempPos = transform.position;
        tempPos.y -= moveSpeed * Time.deltaTime;
        transform.position = tempPos;
    }

    private void OnDisable()
    {
        SoundManager.instance.PlayPickUpSound();
    }
}