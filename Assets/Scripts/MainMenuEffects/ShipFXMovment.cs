using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFXMovment : MonoBehaviour
{
    [SerializeField] private float minSpeed = 10f, maxSpeed = 20f;


    private bool moveHorizontal, moveVertical;
    private float speed;
    private Vector3 tempPos;

    private void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().flipY = true;
    }


    private void OnEnable()
    {
        if (Random.Range(0, 2) > 0) moveHorizontal = true;
        else moveHorizontal = false;

        if (Random.Range(0, 2) > 0) moveVertical = true;
        else moveVertical = false;

        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        MoveVertical();
        MoveHorizontal();
    }

    private void MoveVertical()
    {

        if (!moveVertical) return;
        tempPos = transform.position;
        tempPos.y += speed * Time.deltaTime;
        transform.position = tempPos;
    }

    private void MoveHorizontal()
    {
        if (!moveHorizontal) return;
        tempPos = transform.position;
        tempPos.y -= speed * Time.deltaTime;
        transform.position = tempPos;
    }
}
