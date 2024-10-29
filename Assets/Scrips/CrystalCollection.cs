using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrystalCollection : MonoBehaviour
{
    [SerializeField] GameObject crystal;
    [SerializeField] GameObject crystalHolder;
    [SerializeField] GameObject icon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "manaCrystal")
        {
            crystal.SetActive(false);
            crystalHolder.GetComponent<BoxCollider>().enabled = true;
            icon.SetActive(true);
        }
    }
}
