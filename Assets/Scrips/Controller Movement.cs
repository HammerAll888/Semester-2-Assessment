//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Windows;

//public class ControllerMovement : MonoBehaviour
//{
//    private InputHandler _input; //References the InputHandler script
//    public CameraManager CameraManager; //Referebces the CameraManager script

//    //List of game objects used in the script
//    [SerializeField] private float moveSpeed;
//    [SerializeField] private Camera cam;
//    [SerializeField] private float rotateSpeed;
//    [SerializeField] private bool rotateTowardsMouse;

//    //List of variables needed to apply jump force
//    public float jumpForce = 5;
//    public float groundDistance = 1;

//    Rigidbody rb;

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    void Update()
//    {
//        //Makes the character face the direction of travel
//        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);

//        var movementVector = MoveTowardTarget(targetVector);

//        if (!rotateTowardsMouse)
//            RotateTowardMovementVector(movementVector);
//        else
//            RotateTowardMovementVector();

//        //Detects when the player will rotate the camera
//        if (Input.GetKeyDown(KeyCode.Q))
//        {
//            CameraManager.SwitchCamera(CameraManager.cam1);
//        }
//        if (Input.GetKeyDown(KeyCode.E))
//        {
//            CameraManager.SwitchCamera(CameraManager.cam2);
//        }

//        //This will make the character jump on space bar input
//        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
//        {
//            rb.velocity = Vector3.up * jumpForce;
//        }
//    }
//}
