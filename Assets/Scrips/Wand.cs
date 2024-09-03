using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    public Transform magicBlastSpawn;
    public GameObject magicBlastPrefab;
    public float magicBlastSpeed = 10;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            var magicBlast = Instantiate(magicBlastPrefab, magicBlastSpawn.position, magicBlastSpawn.rotation);
            magicBlast.GetComponent<Rigidbody>().velocity = magicBlastSpawn.forward * magicBlastSpeed;
        }
    }
}
