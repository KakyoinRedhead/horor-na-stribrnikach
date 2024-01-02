using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject doorClosed, doorOpened, intIcon;
    public bool doorClosedBool;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(true);

            if (Input.GetKey(KeyCode.E) && doorClosedBool == true)
            {
                intIcon.SetActive(false);
                doorClosed.SetActive(false);
                doorOpened.SetActive(true);
                doorClosedBool = false;
            }
            else if (Input.GetKey(KeyCode.E) && doorClosedBool == false)
            {
                intIcon.SetActive(false);
                doorClosed.SetActive(true);
                doorOpened.SetActive(false);
                doorClosedBool = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(false);
        }
    }
}
