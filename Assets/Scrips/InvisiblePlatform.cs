using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePlatform : MonoBehaviour
{
    [SerializeField] GameObject invisiblePlatform;

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

    private IEnumerator TogglePlatform(bool isActive, float delay)
    {
        yield return new WaitForSeconds(delay);
        invisiblePlatform.SetActive(isActive);
    }
}
