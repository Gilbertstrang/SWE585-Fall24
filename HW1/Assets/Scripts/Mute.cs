using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
    public AudioSource audioSource;

    private bool isPlaying = true;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

       
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (isPlaying)
            {
                audioSource.Pause();
                isPlaying = false;
            }
            else
            {
                audioSource.UnPause();
                isPlaying = true;
            }
        }
    }
}
