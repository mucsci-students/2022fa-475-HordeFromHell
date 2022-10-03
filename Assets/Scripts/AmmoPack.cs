using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class AmmoPack : MonoBehaviour
{
    public FirstPersonController FPC;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player" && FPC.GetComponent<bullet>().ammo < 31)
        {
            FPC.GetComponent<bullet>().addAmmo(20);
            Destroy(gameObject);
        }
    }
}
