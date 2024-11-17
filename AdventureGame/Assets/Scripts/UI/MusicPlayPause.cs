using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicPlayPause : MonoBehaviour
{
    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TogglePlayback(bool musicPlaying)
    {
        Debug.Log("Toggled");
        if (musicPlaying)
        {
            Debug.Log("Music Paused");
            audioSource.Pause();
        }
        else
        {
            Debug.Log("Music Playing");
            audioSource.Play();
        }
    }
}
