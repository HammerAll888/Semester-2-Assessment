using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TopDownCharacterMover : MonoBehaviour
{
    private InputHandler _input; //References the InputHandler script
    public CameraManager CameraManager; //References the CameraManager script

    //List of game objects used in the script
    [SerializeField] private float moveSpeed;
    [SerializeField] private Camera cam;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private bool rotateTowardsMouse;

    //List of variables needed to apply jump force
    public float jumpForce = 5;
    public float groundDistance = 1;
    public float gravityMultiplier = 2f;

    Rigidbody rb;

    //External components needed for movemnet
    private void Awake()
    {
        _input = GetComponent<InputHandler>();
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Update()
    {
        //Makes the character face the direction of travel
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);

        var movementVector = MoveTowardTarget(targetVector);

        if (!rotateTowardsMouse)
            RotateTowardMovementVector(movementVector);
        else
            RotateTowardMovementVector();

        //Detects when the player will rotate the camera
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CameraManager.SwitchCamera(CameraManager.cam1);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            CameraManager.SwitchCamera(CameraManager.cam2);
        }

        //This will make the character jump on space bar input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = Vector3.up * jumpForce;
        }

        if (!isGrounded())
        {
            rb.velocity += Vector3.down * gravityMultiplier * Physics.gravity.y * Time.deltaTime;
        }
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundDistance);
    }

    private void RotateTowardMovementVector()
    {
        Plane groundPlane = new Plane(Vector3.up, transform.position);
        Ray ray = cam.ScreenPointToRay(_input.MousePosition);

        if(groundPlane.Raycast(ray, out float distance))
        {
            Vector3 targetPoint = ray.GetPoint(distance);

            Vector3 direction = (targetPoint - transform.position).normalized;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }

    //Makes the character face the direction of travel
    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        if (movementVector.magnitude == 0) { return; }
        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }

    //Makes the player move in the targeted direction
    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.deltaTime;

        targetVector = Quaternion.Euler(0, cam.gameObject.transform.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;
        return targetVector;
    }
}