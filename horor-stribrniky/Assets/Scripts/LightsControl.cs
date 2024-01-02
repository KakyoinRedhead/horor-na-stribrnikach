using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsControl : MonoBehaviour
{
    public GameObject lights, intIcon;
    public bool lightOff;
    private bool interactionStarted = false;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(true);

            if (Input.GetKey(KeyCode.E) && lightOff == true && !interactionStarted)
            {
                interactionStarted = true;
                intIcon.SetActive(false);
                lights.SetActive(true);
                lightOff = false;
            }
            else if (Input.GetKey(KeyCode.E) && lightOff == false && !interactionStarted)
            {
                interactionStarted = true;
                intIcon.SetActive(false);
                lights.SetActive(false);
                lightOff = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(false);
            interactionStarted = false;
        }
    }
}
