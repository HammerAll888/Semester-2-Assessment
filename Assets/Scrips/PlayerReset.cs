using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    public Transform startPos;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        Player.transform.position = startPos.transform.position;
    }
}
