using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    [SerializeField] private bool moveOnX, moveOnY;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float horizontalMovmentTreshold = 8f;
    [SerializeField] private float verticalMovmentTreshold = 6f;

    private bool moveLeft = false;
    private bool moveUp = false;
    private float minX, maxX;
    private float minY, maxY;
    private Vector3 tempMovmentHorizontal;
    private Vector3 tempMovmentVertical;

    private void Start()
    {
        minX = transform.position.x - horizontalMovmentTreshold;
        maxX = transform.position.x + horizontalMovmentTreshold;

        minY = transform.position.y - verticalMovmentTreshold;
        maxY = transform.position.y;

        if(Random.Range(0,2) > 0)
            moveLeft = true;
    }

    private void Update()
    {
        HandleEnemyMovmentHorizontal();
        HandleEnemyMovmentVertical();
    }

    private void HandleEnemyMovmentHorizontal()
    {
        if (!moveOnX)
            return;
        if (moveLeft)
        {
            tempMovmentHorizontal = transform.position;
            tempMovmentHorizontal.x -= moveSpeed * Time.deltaTime;
            transform.position = tempMovmentHorizontal;
            if (tempMovmentHorizontal.x < minX)
                moveLeft = false;
        }
        else
        {
            tempMovmentHorizontal = transform.position;
            tempMovmentHorizontal.x += moveSpeed * Time.deltaTime;
            transform.position = tempMovmentHorizontal;
            if (tempMovmentHorizontal.x > maxX)
                moveLeft = true;
        }


    }

    private void HandleEnemyMovmentVertical()
    {
        if (!moveOnY)
            return;

        if(!moveUp)
        {
            tempMovmentVertical = transform.position;
            tempMovmentVertical.y -= moveSpeed * Time.deltaTime;
            transform.position = tempMovmentVertical;
            if (tempMovmentVertical.y < minY)
                moveUp = true;
        }
        else
        {
            tempMovmentVertical = transform.position;
            tempMovmentVertical.y += moveSpeed * Time.deltaTime;
            transform.position = tempMovmentVertical;
            if (tempMovmentVertical.y > maxY)
                moveUp = false;
        }
    }
}
