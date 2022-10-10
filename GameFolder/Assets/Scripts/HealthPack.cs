using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class HealthPack : MonoBehaviour
{
    public FirstPersonController FPC;
    
    void Start()
    {
        FPC = FindObjectOfType<FirstPersonController>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && FPC.GetComponent<PlayerHealth>().currentHealth < 100)
        {
            if(PlayerPrefs.GetInt("Difficulty") == 0)
            {
            FPC.GetComponent<PlayerHealth>().Heal(20);
            }
            else if(PlayerPrefs.GetInt("Difficulty") == 1)
            {
            FPC.GetComponent<PlayerHealth>().Heal(15);
            }
            else
            {
            FPC.GetComponent<PlayerHealth>().Heal(10);
            }
            Destroy(gameObject);
        }
    }
}
