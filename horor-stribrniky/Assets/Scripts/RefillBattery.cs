using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillBattery : MonoBehaviour
{
    public GameObject intIcon, baterky;


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {

                Battery batteryScript = GameObject.Find("BatteryO").GetComponent<Battery>();
                Destroy(gameObject);

                if (batteryScript != null)
                {
                    if (batteryScript.batteryInvCount < 2)
                    {
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
        }
    }
}
