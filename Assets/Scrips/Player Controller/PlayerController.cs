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

    // Added variables for camera switching
    public CameraManager cameraManager; // Reference to your CameraManager
    private InputAction switchCameraAction; // Input action for switching cameras

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        characterController = GetComponent<CharacterController>();

        // Initialize the input action for switching cameras
        switchCameraAction = inputActions.Player.SwitchCamera; // Assuming you have a SwitchCamera action in your input settings
    }

    private void OnEnable()
    {
        inputActions.Enable();

        // Enable and subscribe to the camera switching input
        switchCameraAction.performed += OnSwitchCamera; // Added code for camera switching
        switchCameraAction.Enable(); // Added code for camera switching
    }

    private void OnDisable()
    {
        inputActions.Disable();

        // Unsubscribe and disable the camera switching input
        switchCameraAction.performed -= OnSwitchCamera; // Added code for camera switching
        switchCameraAction.Disable(); // Added code for camera switching
    }

    private void Update()
    {
        // Check if the player is on the ground
        isGrounded = characterController.isGrounded;

        // Handle movement
        Vector2 moveInput = inputActions.Player.Movement.ReadValue<Vector2>();
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y).normalized * moveSpeed;

        // Only rotate towards movement direction if there is movement
        if (moveDirection.magnitude > 0)
        {
            // Rotate towards the movement direction
            RotateTowardsMovementDirection(moveDirection); // Changed code
        }

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
    }

    // Added method to rotate towards movement direction
    private void RotateTowardsMovementDirection(Vector3 moveDirection) // Changed code
    {
        if (moveDirection != Vector3.zero) // Changed code
        {
            // Changed code: Calculate target rotation based on movement direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection); // Changed code

            // Rotate towards the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    // Added method to handle camera switching
    private void OnSwitchCamera(InputAction.CallbackContext context)
    {
        if (context.control.name == "rightShoulder")
        {
            cameraManager.SwitchCamera(cameraManager.cam2); // Switch to camera 2
        }
        else if (context.control.name == "leftShoulder") // Assuming "buttonWest" for switching to camera 1
        {
            cameraManager.SwitchCamera(cameraManager.cam1); // Switch to camera 1
        }
    }
}
