using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoop : MonoBehaviour
{
    public AudioClip menu;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = menu;
        audioSource.loop = true;
        audioSource.Play();
    }

   
    void Update()
    {
        
    }
}
