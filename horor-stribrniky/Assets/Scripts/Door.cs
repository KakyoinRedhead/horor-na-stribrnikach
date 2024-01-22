using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject doorClosed, doorOpened, intIcon, openUpText;
    public bool doorClosedBool;
    private bool eKeyPressed = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            openUpText.SetActive(true);
            intIcon.SetActive(true);

            if (Input.GetKey(KeyCode.E) && !eKeyPressed)
            {
                eKeyPressed = true;
                ToggleDoor();
                StartCoroutine(ResetEKeyPressed());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(false);
            doorClosed.SetActive(false);
            doorOpened.SetActive(false);
        }
    }

    private void ToggleDoor()
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

    private System.Collections.IEnumerator ResetEKeyPressed()
    {
        yield return new WaitForSeconds(0.5f);
        eKeyPressed = false;
    }
}
