using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveKeyboard : MonoBehaviour
{
    [SerializeField] private float speed = 600f;

    new private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovment();
    }

    private void HandleMovment()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            rigidbody2D.AddForce(transform.up * speed);

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            rigidbody2D.AddForce(-transform.up * speed);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            rigidbody2D.AddForce(transform.right * speed);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            rigidbody2D.AddForce(-transform.right * speed);
    }

}
