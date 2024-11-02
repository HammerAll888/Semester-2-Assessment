using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    //List of variables
    public Transform magicBlastSpawn;
    public GameObject magicBlastPrefab;
    public float magicBlastSpeed = 10;

    //Will check for M1 input and will fire a magic blast
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            var magicBlast = Instantiate(magicBlastPrefab, magicBlastSpawn.position, magicBlastSpawn.rotation);
            magicBlast.GetComponent<Rigidbody>().velocity = magicBlastSpawn.forward * magicBlastSpeed;

            Destroy(magicBlast, 3f);
        }
    }
}
