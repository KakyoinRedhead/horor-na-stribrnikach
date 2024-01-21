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
                    batteryScript.bPercent = 100;
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
