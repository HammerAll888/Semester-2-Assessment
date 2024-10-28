using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrystalPlacement : MonoBehaviour
{
    [SerializeField] GameObject crystal;
    [SerializeField] GameObject portalIris;

    bool inRange;

    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }

    private void Update()
    {
        if(inRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                crystal.SetActive(true);
                portalIris.SetActive(true);
                portalIris.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
}
