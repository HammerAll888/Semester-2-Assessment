using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] GameObject HiddenPlatform;
    public Transform hiddenplatform;
    public float moveDistance = 2f;
    public float moveSpeed = 2f;
    private Vector3 originalPos;
    private bool isMoving = false;

    private void Start()
    {
        originalPos = hiddenplatform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("magicBlast"))
        {
            isMoving = true;
        }
    }

    private void Update()
    {
        if(isMoving)
        {
            MovePlatformUp();
        }
    }

    private void MovePlatformUp()
    {
        if(hiddenplatform.position.y < originalPos.y + moveDistance)
        {
            hiddenplatform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
    }
}
