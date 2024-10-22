using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions inputActions;
    private CharacterController characterController;

    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;
    public float jumpHeight = 2f;

    private Vector3 velocity;
    private bool isGrounded;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        // Check if the player is on the ground
        isGrounded = characterController.isGrounded;

        // Handle movement
        Vector2 moveInput = inputActions.Player.Movement.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y).normalized * moveSpeed;

        if (isGrounded)
        {
            // Jumping
            if (inputActions.Player.Jump.triggered)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y); // Jump force calculation
            }
        }

        // Apply gravity continuously
        velocity.y += Physics.gravity.y * Time.deltaTime;

        // Move the player
        characterController.Move((moveDirection + velocity) * Time.deltaTime);

        // Handle rotation
        Vector2 rotateInput = inputActions.Player.Rotation.ReadValue<Vector2>();
        if (rotateInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(rotateInput.x, rotateInput.y) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
