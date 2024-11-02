using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePortal : MonoBehaviour
{
    [SerializeField] GameObject portalIris;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToggleIris(true, 2.5f));     //Will delay when the purple portal gets activated
    }

    private IEnumerator ToggleIris(bool isActive, float delay)
    {
        yield return new WaitForSeconds(delay);     //This finds the courtine making the program wait
        portalIris.SetActive(isActive);     //This will turn on the purple portal
    }
}
