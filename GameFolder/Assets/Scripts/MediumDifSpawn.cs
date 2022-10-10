using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumDifSpawn : MonoBehaviour
{
    void Start()
    {
        if(PlayerPrefs.GetInt("Difficulty") == 1)
        {
            Destroy(gameObject);
        }
    }
}
