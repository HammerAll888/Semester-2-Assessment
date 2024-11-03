using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePlatform : MonoBehaviour
{
    //Gets a reference to the gameobject
    private List<GameObject> invisiblePlatformL;
    private List<GameObject> invisiblePlatformR;

    private void Start()
    {
        //Creates a list of any gameobject with these tags
        invisiblePlatformL = new List<GameObject>(GameObject.FindGameObjectsWithTag("invisiblePlatformL"));
        invisiblePlatformR = new List<GameObject>(GameObject.FindGameObjectsWithTag("invisiblePlatformR"));

        foreach(GameObject platform in invisiblePlatformL)
        {
            platform.SetActive(true);       //invisiblePlatformL starts visible
        }
        foreach(GameObject platform in invisiblePlatformR)
        {
            platform.SetActive(false);      //invisiblePlatformR starts invisible
        }
    }

    //Will make the platofrm invisible when the buttons are pressed
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(TogglePlatform(false, 1.2f));    //Makes the program wait 1.2 seconds before turning off the plaform
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(TogglePlatform(true, 1.2f));     //Makes the program wait 1.2 seconds before turning off the plaform
            }
        }
    }

    private IEnumerator TogglePlatform(bool isActiveR, float delay)
    {
        yield return new WaitForSeconds(delay);

        foreach(GameObject platform in invisiblePlatformL)
        {
            platform.SetActive(!isActiveR);
        }
        foreach(GameObject platform in invisiblePlatformR)
        {
            platform.SetActive(isActiveR);
        }
    }
}
