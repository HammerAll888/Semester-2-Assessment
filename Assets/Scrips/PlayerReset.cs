using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    //Will find the objects listed below
    public Transform startPos;
    public GameObject Player;

    //Will send player back to the 'startPos' when the 'Player' enters the 'PlayerReset'
    private void OnTriggerEnter(Collider other)
    {
        Player.transform.position = startPos.transform.position;
    }
}
