using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorFXMovement : MonoBehaviour
{
    [SerializeField] private float minSpeed = 5, maxSpeed = 10;
    [SerializeField] private float minRotationSpeed = 5f, maxRotationSpeed = 10f;

    private bool moveOnX = false;
    private float speedY, speedX;
    private float rotationSpeed;
    private float zRotation;
    private Vector3 tempPos;

    private void Awake()
    {
        speedY = Random.Range(minSpeed, maxSpeed);
        speedX = Random.Range(minSpeed, minSpeed);

        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);

        if (Random.Range(0, 2) > 0)
            moveOnX = true;

        if (Random.Range(0, 2) > 0)
            speedX *= -1;

        if (Random.Range(0, 2) > 0)
            rotationSpeed *= -1;
    }

    private void Update()
    {
        HandleMovment();
        HandleRotation();
    }

    private void HandleMovment()
    {
        tempPos = transform.position;
        tempPos.y -= speedY * Time.deltaTime;
        transform.position = tempPos;

        if (!moveOnX)
            return;

        tempPos = transform.position;
        tempPos.x += speedX * Time.deltaTime;
        transform.position = tempPos;
    }

    private void HandleRotation()
    {
        zRotation += rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.AngleAxis(zRotation, Vector3.forward);
    }
}
