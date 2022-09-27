using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    float bounce = 0.2f;
    float elapsedTime = 0f;
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(true) {
            if(elapsedTime <= bounce){
                transform.position = new Vector3(0,0.002f,0) * Time.deltaTime;
            } else if(elapsedTime > bounce) {
                transform.position = new Vector3(0,-0.002f,0) * Time.deltaTime;
            } else if(elapsedTime > bounce * 2) {
                elapsedTime = 0f;
            }
             
        }
    }
}
