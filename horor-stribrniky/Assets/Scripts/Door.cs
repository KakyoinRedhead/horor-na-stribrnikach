using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject doorClosed, doorOpened, intIcon;
    public bool doorClosedBool;
    private bool eKeyPressed = false;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E) && !eKeyPressed)
            {
                eKeyPressed = true; 
                ToggleDoor();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(false);
            eKeyPressed = false; 
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            eKeyPressed = false;
        }
    }

    void ToggleDoor()
    {
        if (doorClosedBool)
        {
            intIcon.SetActive(false);
            doorClosed.SetActive(false);
            doorOpened.SetActive(true);
            doorClosedBool = false;
        }
        else
        {
            intIcon.SetActive(false);
            doorClosed.SetActive(true);
            doorOpened.SetActive(false);
            doorClosedBool = true;
        }
    }
}
