using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RefillBattery : MonoBehaviour
{
    public GameObject intIcon, baterky, pickUpText;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(true);
            pickUpText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {

                Battery batteryScript = GameObject.Find("BatteryO").GetComponent<Battery>();
                

                if (batteryScript != null)
                {
                    if (batteryScript.batteryInvCount < 2)
                    {
                        intIcon.SetActive(false);
                        pickUpText.SetActive(false);
                        Destroy(gameObject);
                        batteryScript.batteryInvCount += 1;
                    }
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
