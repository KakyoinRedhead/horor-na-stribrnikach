using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCont : MonoBehaviour
{
    public GameObject intIcon, terminal, cameraObj, cameraUI, playerCamera, playerUI;
    private bool isOnCam = false;

void OnTriggerStay(Collider other)
{
        if (other.CompareTag("MainCamera"))
        {
            intIcon.SetActive(true);

            if (Input.GetKey(KeyCode.E) && isOnCam == false)
            {
                PlayerMovement player = GameObject.Find("PlayerC").GetComponent<PlayerMovement>();
                CameraScript playerCam = GameObject.Find("PlayerCam").GetComponent<CameraScript>();
                Battery batteryScript = GameObject.Find("BatteryO").GetComponent<Battery>();
                playerCam.canMoveCam = false;
                player.canMove = false;
                batteryScript.canHaveLight = false;
                playerUI.SetActive(false);
                cameraObj.SetActive(true);
                cameraUI.SetActive(true);
                isOnCam = true;
            }
            else if (Input.GetKey(KeyCode.Space) && isOnCam == true)
            {
                PlayerMovement player = GameObject.Find("PlayerC").GetComponent<PlayerMovement>();
                CameraScript playerCam = GameObject.Find("PlayerCam").GetComponent<CameraScript>();
                Battery batteryScript = GameObject.Find("BatteryO").GetComponent<Battery>();
                cameraUI.SetActive(false);
                cameraObj.SetActive(false);
                playerUI.SetActive(true);
                player.canMove = true;
                playerCam.canMoveCam =true;
                batteryScript.canHaveLight = true;
                isOnCam = false;
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
