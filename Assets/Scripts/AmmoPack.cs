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
            FPC.GetComponent<bullet>().addAmmo(15);
            Destroy(gameObject);
        }
    }
}
