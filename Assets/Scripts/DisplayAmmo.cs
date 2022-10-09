using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayAmmo : MonoBehaviour
{
    public TextMeshProUGUI ammoCount;

    public void UpdateAmmo(int num)
    {
        ammoCount.text = "Ammo: " + num;
    }
}
