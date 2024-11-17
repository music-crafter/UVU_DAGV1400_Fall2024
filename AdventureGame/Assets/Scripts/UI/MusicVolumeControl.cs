using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeControl : MonoBehaviour
{
    private AudioSource musicSource;
    public Slider volumeSlider;
    
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        volumeSlider.value = musicSource.volume;
        volumeSlider.onValueChanged.AddListener(AdjustVolume);
    }

    public void AdjustVolume(float newVolume)
    {
        musicSource.volume = newVolume;
    }
}
