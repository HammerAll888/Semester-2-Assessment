using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MagicBlastLvl2 : MonoBehaviour
{
    [SerializeField] GameObject hiddenPlatform;
    public Transform HiddenPlatform;
    public float moveDistance = 2f;
    public float moveSpeed = 2f;
    private Vector3 originalPos;
    private bool isMoving = false;

    private void Start()
    {
        originalPos = HiddenPlatform.position;
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
        if(HiddenPlatform.position.y < originalPos.y + moveDistance)
        {
            HiddenPlatform.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
        }
    }
}
