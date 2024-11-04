using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] GameObject Platform;
    [SerializeField] GameObject Light;
    public Transform platform; //Defines the platform object
    public float moveDistance = 2f; // How far the platform will move
    public float moveSpeed = 2f; // Speed of the platform moving
    private Vector3 originalPos;
    private bool isMoving = false;

    private void Start()
    {
        // Store the original position of the platform
        originalPos = platform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure the player has the tag "Player"
        {
            isMoving = true;
        }

        Light.SetActive(true);
    }

    private void Update()
    {
        if (isMoving)
        {
            MovePlatformUp();
        }
    }

    private void MovePlatformUp()
    {
        if (platform.position.y < originalPos.y + moveDistance)
        {
            platform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
    }
}