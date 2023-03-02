using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovmentInPoints : MonoBehaviour
{   
    [SerializeField] private bool moveRandomly;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform[] movementPoints;

    private int currentMoveIndex;
    private Vector3 targetPosition;

    private void Start()
    {
        SetTargetPositon();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) <= 0.1f)
        {
            SetTargetPositon();
        }
    }

    private void SetTargetPositon()
    {
        if (moveRandomly)
            SetRandomPosition();
        else
            SelectPointToPointPosition();
    }

    private void SetRandomPosition()
    {
        while (movementPoints[currentMoveIndex].position == targetPosition)
        {
            currentMoveIndex = UnityEngine.Random.Range(0, movementPoints.Length);
        }

        targetPosition = movementPoints[currentMoveIndex].position;
    }

    private void SelectPointToPointPosition()
    {
        if (currentMoveIndex == movementPoints.Length)
            currentMoveIndex = 0;

        targetPosition = movementPoints[currentMoveIndex].position;

        currentMoveIndex++;
    }
}
