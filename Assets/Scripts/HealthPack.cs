using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class HealthPack : MonoBehaviour
{
    public FirstPersonController FPC;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && FPC.GetComponent<PlayerHealth>().currentHealth < 100)
        {
            FPC.GetComponent<PlayerHealth>().Heal(15);
            Destroy(gameObject);
        }
    }
}
