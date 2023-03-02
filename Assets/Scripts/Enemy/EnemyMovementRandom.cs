using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementRandom : MonoBehaviour
{
    [SerializeField] private float minX, maxX, minY, maxY;
    [SerializeField] private float moveSpeed = 8f;

    private Vector3 targetPositon;

    private void Start()
    {
        SetTargetPosition();
    }

    private void Update()
    {
        Move();
    }

    private void SetTargetPosition()
    {
        targetPositon = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPositon, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPositon) < 0.1f) 
            SetTargetPosition();
    }
}
