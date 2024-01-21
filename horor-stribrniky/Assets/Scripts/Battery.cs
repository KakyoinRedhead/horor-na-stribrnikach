using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    public float timing;
    bool buttonPressOn = true;
    public GameObject lightB, batteryIcon;
    public Image batteryImageTop, batteryImageMidTop, batteryImageMid, batteryImageBottom;
    public bool batteryIsOff = true;
    public int bPercent;
    public bool haveBattery = true;
    private Coroutine percentCountCoroutine;
    private Color myGreen = new Color(0.102f, 0.925f, 0.196f);
    private Color myOrange = new Color(1f, 0.5f, 0f);

    private void Update()
    {
        Checks();
    }
    private void TurnOnAndOff()
    {
        buttonPressOn = !buttonPressOn;
        batteryIsOff = !batteryIsOff;
        lightB.SetActive(!buttonPressOn);
    }
    private void Checks()
    {
        if (bPercent > 0 && batteryIsOff == false && percentCountCoroutine == null) 
        {
            percentCountCoroutine = StartCoroutine(percentCount());
            haveBattery = true;
        }
        else if(bPercent <= 0) 
        {
            haveBattery = false;
            lightB.SetActive(false); 
            batteryIsOff = true;

            if (percentCountCoroutine != null)
            {
                StopCoroutine(percentCountCoroutine);
                percentCountCoroutine = null;
            }
        }
        BatteryPercentCheck();

    }
    private void BatteryPercentCheck() 
    {
        if (bPercent >= 75)
        {
            batteryImageTop.enabled = true;
            batteryImageMidTop.enabled = true;
            batteryImageMid.enabled = true;
            batteryImageBottom.enabled = true;

            batteryImageTop.color = myGreen;
            batteryImageMidTop.color = myGreen;
            batteryImageMid.color = myGreen;
            batteryImageBottom.color = myGreen;

        }
        if (bPercent <= 75)
        {
            batteryImageTop.enabled = false;
            batteryImageMidTop.color = Color.yellow;
            batteryImageMid.color = Color.yellow;
            batteryImageBottom.color = Color.yellow;

        }
        if (bPercent <= 50)
        {
            batteryImageMidTop.enabled = false;
            batteryImageMid.color = myOrange;
            batteryImageBottom.color = myOrange;
        }
        if (bPercent <= 25)
        {
            batteryImageMid.enabled = false;
            batteryImageBottom.color = Color.red;
        }
        if (bPercent <= 0)
        {
            batteryImageBottom.enabled = false;
        }


        if (Input.GetKeyDown(KeyCode.F) && haveBattery == true)
        {
            TurnOnAndOff();
        }
    }
    private IEnumerator percentCount()
    {
            

        while (bPercent > 0 && !batteryIsOff)
        {
            yield return new WaitForSeconds(timing);

            bPercent -= 1;
        }
        percentCountCoroutine = null;
    }

}
