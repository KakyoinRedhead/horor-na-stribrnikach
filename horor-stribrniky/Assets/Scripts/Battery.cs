using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    bool ButtonPressOn = false;
    public GameObject lightB;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TurnOnAndOff();
        }
    }

    private void TurnOnAndOff()
    {
        ButtonPressOn = !ButtonPressOn;
        lightB.SetActive(!ButtonPressOn);
    }
}
