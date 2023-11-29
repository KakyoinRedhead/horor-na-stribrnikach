using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using Slider = UnityEngine.UI.Slider;
using Toggle = UnityEngine.UI.Toggle;

public class SettingsMenu : MonoBehaviour
{
    public Text sliderValue;
    public Slider fpsSlider;
    public Toggle vSync;
    public int target = 60;

    public Text volumeValue;
    public Slider volumeSlider;
    public AudioSource audioSource;

    public GameObject mainMenu;
    public GameObject settMenu;
    void Start()
    {
        
    }

    void Update()
    {
        //number under every slider to tell for example how much fps it is
        sliderValue.text = fpsSlider.value.ToString();
        volumeValue.text = ((int)(volumeSlider.value*100)).ToString() + "%";

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            settMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
    }

    //changing fps with fps slider value
    public void SetFps()
    {
        target = (int)fpsSlider.value;
        Application.targetFrameRate = target;
    }

    //turning on/off VSync
    public void SetVSyncOn()
    {
        if (vSync.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }

    //same as SetFps but with volume
    public void SetVolume()
    {
        audioSource.volume = volumeSlider.value;
    }
    public void BackToMain()
    {
        settMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
