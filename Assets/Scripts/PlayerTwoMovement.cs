using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoMovement : MonoBehaviour
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

        // Check arrow key inputs for movement
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            moveX = 1f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveZ = 1f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
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