using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    [SerializeField] GameObject doorClosed;
    [SerializeField] GameObject doorOpened;
    [SerializeField] GameObject light;

    private void OnTriggerEnter(Collider other)
    {
        doorClosed.SetActive(false);
        doorOpened.SetActive(true);
        light.SetActive(true);
    }
}
