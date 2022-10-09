using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulties : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("Difficulty", 0);
    }

    public void EasyButtonClicked()
    {
        PlayerPrefs.SetInt("Difficulty", 0);
    }

    public void MediumButtonClicked()
    {
        PlayerPrefs.SetInt("Difficulty", 1);
    }

    public void HardButtonClicked()
    {
        PlayerPrefs.SetInt("Difficulty", 2);
    }
}
