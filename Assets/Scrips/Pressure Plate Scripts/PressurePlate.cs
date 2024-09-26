using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] GameObject Platform;
    public Transform platform; //Defines the platform object
    public float moveDistance = 2f; // How far the platform will move
    public float moveSpeed = 2f; // Speed of the platform moving
    private Vector3 originalPosition;
    private bool isMoving = false;

    private void Start()
    {
        // Store the original position of the platform
        originalPosition = platform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure the player has the tag "Player"
        {
            isMoving = true;
        }
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
        if (platform.position.y < originalPosition.y + moveDistance)
        {
            platform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
    }

    private System.Collections.IEnumerator MovePlatformBack()
    {
        while (platform.position.y > originalPosition.y)
        {
            platform.position -= new Vector3(0, moveSpeed * Time.deltaTime, 0);
            yield return null; // Wait for the next frame
        }
        platform.position = originalPosition; // Ensure it snaps back to the original position
    }
}