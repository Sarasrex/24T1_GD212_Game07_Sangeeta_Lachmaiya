using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMovement : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody rb;
    private bool isGrounded;
    public LayerMask groundLayer;
    public GameObject bluePlayer;

    void Start()
    {
        rb = bluePlayer.GetComponentInChildren<Rigidbody>();
    }

    void Update()
    {
        // Check for ground
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f, groundLayer);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        if (Input.GetKey(KeyCode.A))
        {
            movement = new Vector3(-speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement = new Vector3(speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            movement = new Vector3(0, 0, speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement = new Vector3(0, 0, -speed);
        }

        // Apply the movement to the Rigidbody
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);


    }
}
