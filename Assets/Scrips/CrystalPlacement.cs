using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GemPlacement : MonoBehaviour
{
    public GameObject crystal;
    public Transform holder;
    private bool canPlaceCrystal = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Holder"))
        {
            canPlaceCrystal = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Holder"))
        {
            canPlaceCrystal = false;
        }
    }

    public void OnPlaceCrystal(InputAction.CallbackContext context)
    {
        if(context.performed && canPlaceCrystal && crystal != null)
        {
            crystal.transform.position = holder.position;
            crystal.transform.parent = holder;
        }
    }
}
