using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Battery : MonoBehaviour
{
    bool buttonPressOn = true;
    public GameObject lightB;
    public bool batteryIsOff = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TurnOnAndOff();
        }

    }
    private void TurnOnAndOff()
    {
        buttonPressOn = !buttonPressOn;
        batteryIsOff = !batteryIsOff;
        lightB.SetActive(!buttonPressOn);
    }
}
