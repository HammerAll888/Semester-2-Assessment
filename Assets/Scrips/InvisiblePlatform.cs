using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePlatform : MonoBehaviour
{
    [SerializeField] GameObject invisiblePlatform;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(TogglePlatform(false, 1.2f));
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(TogglePlatform(true, 1.2f));
            }
        }
    }

    private IEnumerator TogglePlatform(bool isActive, float delay)
    {
        yield return new WaitForSeconds(delay);
        invisiblePlatform.SetActive(isActive);
    }
}
