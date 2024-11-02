using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrystalPlacement : MonoBehaviour
{
    [SerializeField] GameObject empty;
    [SerializeField] GameObject filled;
    [SerializeField] GameObject icon;

    bool inRange;   //Defines when the player is in the box collider

    //Makes the player in range of the crystal bot
    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
    }

    //Makes the player no longer in range of the crystal pot
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
    }

    //Will only activate when the player is in range
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
