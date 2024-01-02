using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    public GameObject drawerClosed, drawerOpened, intIcon;
    public bool drawerClosedBool;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(true);

            if (Input.GetKey(KeyCode.E) && drawerClosedBool == true)
            {
                intIcon.SetActive(false);
                drawerClosed.SetActive(false);
                drawerOpened.SetActive(true);
                drawerClosedBool = false;
            }
            else if (Input.GetKey(KeyCode.E) && drawerClosedBool == false)
            {
                intIcon.SetActive(false);
                drawerClosed.SetActive(true);
                drawerOpened.SetActive(false);
                drawerClosedBool = true;
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
