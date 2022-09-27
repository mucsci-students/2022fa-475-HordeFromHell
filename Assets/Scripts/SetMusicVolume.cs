using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetMusicVolume : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetLevel(float sliderValue)
    {
        // Scales slider values logarithmically instead of linearly
        // because that's how audio decibals scale
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }
}
