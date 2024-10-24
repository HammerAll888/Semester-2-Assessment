using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class UnlockPortal : MonoBehaviour
{
    //Will find the game objecsts listed
    [SerializeField] GameObject manaCrystal;
    //[SerializeField] GameObject endLevelPortal;
    [SerializeField] GameObject crystalHolder;

    //When the player enteres the collider of the 'manaCrystal' it will turn off the 'manaCrystal'
    //It will also turn on the box collider component in the portal allowing the player to move to the next level
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "manaCrystal")
        {
            manaCrystal.SetActive(false);
            //endLevelPortal.GetComponent<BoxCollider>().enabled = true;
            crystalHolder.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
