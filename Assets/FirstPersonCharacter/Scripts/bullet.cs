using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject realBullet;
    public GameObject looksBullet;
	public GameObject viewEnd;
    public GameObject fireEnd;
    public Canvas pauseMenu;
	public float reloadTime;
    float elapsedTime = 0f;
   
    void Update()
    {
	    if(pauseMenu.GetComponent<PauseMenu>().paused == false)
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
}
