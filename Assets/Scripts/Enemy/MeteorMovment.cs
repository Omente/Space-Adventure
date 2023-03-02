using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovment : MonoBehaviour
{
    [SerializeField] private float minSpeed = 4f, maxSpeed = 10f;
    [SerializeField] private float minRotationSpeed = 15f, maxRotationSpeed = 50f;


    private bool moveOnX = false, moveOnY = true;
    private float speedX, speedY;
    private float rotationSpeed;
    private float zRotation;
    private Vector3 tempMovment;

    private void Awake()
    {
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);        
        speedX = Random.Range(minSpeed, maxSpeed);
        speedY = speedX;

        if (Random.Range(0, 2) > 0) speedX *= -1;
        if (Random.Range(0, 2) > 0) rotationSpeed *= -1;
        if (Random.Range(0, 2) > 0) moveOnX = true;
    }

    private void Update()
    {
        HandleMovmentX();
        HandleMovmentY();
        HandleRotation();
    }

    private void HandleMovmentX()
    {
        if (!moveOnX) return;

        tempMovment = transform.position;
        tempMovment.x += speedX * Time.deltaTime;
        transform.position = tempMovment;
    }

    private void HandleMovmentY()
    {
        if (!moveOnY) return;

        tempMovment = transform.position;
        tempMovment.y -= speedY * Time.deltaTime;
        transform.position = tempMovment;
    }

    private void HandleRotation()
    {
        zRotation += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(zRotation, Vector3.forward);
    }
}
