using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetMusicVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    void Start()
    {
        if(PlayerPrefs.HasKey("SliderValue"))
        {
            slider.value = PlayerPrefs.GetFloat("SliderValue");
            SetLevel(PlayerPrefs.GetFloat("SliderValue"));
        }
        else
        {
            slider.value = 0.25f;
            SetLevel(0.25f);
        }
    }

    public void SetLevel(float value)
    {
        // Scales slider values logarithmically instead of linearly
        // because that's how audio decibals scale
        mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("SliderValue", value);
    }
}
