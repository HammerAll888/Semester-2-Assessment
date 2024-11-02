using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatedialogue : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Wand;
    [SerializeField] GameObject Dialogue;
    [SerializeField] GameObject DialogueCollider;

    private void OnTriggerEnter(Collider other)
    {
        Player.GetComponent<TopDownCharacterMover>().enabled = false;
        Wand.GetComponent<Wand>().enabled = false;
        Dialogue.SetActive(true);
        DialogueCollider.SetActive(false);
    }
}
