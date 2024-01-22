using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    public GameObject drawerClosed, drawerOpened, intIcon;
    public bool drawerClosedBool;
    private bool eKeyPressed = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(true);

            if (Input.GetKey(KeyCode.E) && !eKeyPressed)
            {
                eKeyPressed = true;
                ToggleDrawer();
                StartCoroutine(ResetEKeyPressed());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(false);
        }
    }
    private void ToggleDrawer()
    {
        if (drawerClosedBool)
        {
            intIcon.SetActive(false);
            drawerClosed.SetActive(false);
            drawerOpened.SetActive(true);
            drawerClosedBool = false;
        }
        else
        {
            intIcon.SetActive(false);
            drawerClosed.SetActive(true);
            drawerOpened.SetActive(false);
            drawerClosedBool = true;
        }
    }
    private System.Collections.IEnumerator ResetEKeyPressed()
    {
        yield return new WaitForSeconds(0.5f);
        eKeyPressed = false;
    }
}
