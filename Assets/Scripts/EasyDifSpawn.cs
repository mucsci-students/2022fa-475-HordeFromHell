using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyDifSpawn : MonoBehaviour
{
    void Start()
    {
        if(PlayerPrefs.GetInt("Difficulty") == 0)
        {
            Destroy(gameObject);
        }
    }
}
