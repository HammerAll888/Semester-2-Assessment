using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePlatform : MonoBehaviour
{
    private List<GameObject> invisiblePlatformL;
    private List<GameObject> invisiblePlatformR;

    private void Start()
    {
        invisiblePlatformL = new List<GameObject>(GameObject.FindGameObjectsWithTag("invisiblePlatformL"));
        invisiblePlatformR = new List<GameObject>(GameObject.FindGameObjectsWithTag("invisiblePlatformR"));

        foreach(GameObject platform in invisiblePlatformL)
        {
            platform.SetActive(true);
        }
        foreach(GameObject platform in invisiblePlatformR)
        {
            platform.SetActive(false);
        }

        if(invisiblePlatformL.Count == 0 && invisiblePlatformR.Count == 0)
        {
            Debug.LogError("Got it wrong again jack ass");
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
