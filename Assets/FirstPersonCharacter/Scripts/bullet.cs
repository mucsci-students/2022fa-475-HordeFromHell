using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
 
    public GameObject realBullet;
    public GameObject looksBullet;
	public GameObject viewEnd;
    public GameObject fireEnd;
	public float reloadTime = 2f;
    float elapsedTime = 0f;
   
    void Update()
    {
	    elapsedTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && elapsedTime > reloadTime)
        {   
            GameObject bulletFake = Instantiate(looksBullet, viewEnd.transform.position, transform.rotation);
		    Rigidbody bf = bulletFake.GetComponent<Rigidbody>();
            GameObject bullet = Instantiate(realBullet, fireEnd.transform.position, transform.rotation); 
		    Rigidbody b = bullet.GetComponent<Rigidbody>();
            
	        elapsedTime = 0f;
        }
        
    }
 
}
