using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    [SerializeField] GameObject Crystal;

    private void OnTriggerEnter(Collider other)
    {
        Crystal.SetActive(true);
    }
}
