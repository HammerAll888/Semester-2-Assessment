using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBlastTest : MonoBehaviour
{
    //This will destroy any game object tagged 'Target' when collided with
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Target"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
