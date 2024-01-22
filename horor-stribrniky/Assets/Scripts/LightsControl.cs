using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsControl : MonoBehaviour
{
    public GameObject lights, intIcon, switchText;
    public bool lightOff = true;
    private bool interactionStarted = false;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(true);
            switchText.SetActive(true);

            if (Input.GetKey(KeyCode.E) && !interactionStarted)
            {
                interactionStarted = true;
                StartCoroutine(InteractWithLights());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(false);
            switchText.SetActive(false);
        }
    }

    private System.Collections.IEnumerator InteractWithLights()
    {
        if (lightOff)
        {
            lights.SetActive(true);
            lightOff = false;
        }
        else
        {
            lights.SetActive(false);
            lightOff = true;
        }

        yield return new WaitForSeconds(1f);

        interactionStarted = false;
    }
}