using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MagicBlastLvl2 : MonoBehaviour
{
    [SerializeField] GameObject hiddenPlatform;
    public Transform HiddenPlatform;
    public float life = 3;
    public float moveDistance = 2f;
    public float moveSpeed = 2f;
    private Vector3 originalPos;
    private bool isMoving = false;

    private void Start()
    {
        originalPos = HiddenPlatform.position;
    }

    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Target"))
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
