using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class UnlockPortal : MonoBehaviour
{
    [SerializeField] GameObject manaCrystal;
    [SerializeField] GameObject endLevelPortal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "manaCrystal")
        {
            manaCrystal.SetActive(false);
            endLevelPortal.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
