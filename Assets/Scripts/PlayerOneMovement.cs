using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;

    private Vector3 moveDirection;

    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = 0f;
        float moveZ = 0f;

        // Check WASD key inputs for movement
        if (Input.GetKey(KeyCode.W))
        {
            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveX = 1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveZ = 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveZ = -1f;
        }

        moveDirection = new Vector3(moveX, 0f, moveZ).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, 0f, moveDirection.z * moveSpeed);
    }
}