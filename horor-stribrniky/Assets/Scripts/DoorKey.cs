using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public GameObject intIcon, key, pickUpText;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(true);
            pickUpText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {

                LockedDoor lockedDoorScript = GameObject.Find("Doors").GetComponent<LockedDoor>();
                if (lockedDoorScript != null)
                {
                    lockedDoorScript.doorLocked = false;
                    intIcon.SetActive(false);
                    pickUpText.SetActive(false);
                    Destroy(gameObject);
                }

            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(false);
            pickUpText.SetActive(false);

        }
    }
}
