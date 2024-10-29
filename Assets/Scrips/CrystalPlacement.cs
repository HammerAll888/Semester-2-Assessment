using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrystalPlacement : MonoBehaviour
{
    [SerializeField] GameObject empty;
    [SerializeField] GameObject filled;
    [SerializeField] GameObject icon;

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
                icon.SetActive(false);
                empty.SetActive(false);
                filled.SetActive(true);
            }
        }
    }
}
