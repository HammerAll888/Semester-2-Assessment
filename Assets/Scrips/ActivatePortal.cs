using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePortal : MonoBehaviour
{
    [SerializeField] GameObject portalIris;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToggleIris(true, 2.5f));
    }

    private IEnumerator ToggleIris(bool isActive, float delay)
    {
        yield return new WaitForSeconds(delay);
        portalIris.SetActive(isActive);
    }
}
