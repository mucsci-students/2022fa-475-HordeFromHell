using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AmmoPack : MonoBehaviour
{
    public FirstPersonController FPC;

    void Start()
    {
        FPC = FindObjectOfType<FirstPersonController>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && FPC.GetComponent<bullet>().ammo < 200)
        {
            if(PlayerPrefs.GetInt("Difficulty") == 0)
            {
                FPC.GetComponent<bullet>().addAmmo(15);
            }
            else if(PlayerPrefs.GetInt("Difficulty") == 1)
            {
                FPC.GetComponent<bullet>().addAmmo(10);
            }
            else
            {
                FPC.GetComponent<bullet>().addAmmo(5);
            }
            Destroy(gameObject);
        }
    }
}
