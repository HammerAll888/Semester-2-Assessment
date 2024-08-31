using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5;
    public float groundDistance = 1f;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundDistance);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = Vector3.up * jumpForce;
        }
    }
}
