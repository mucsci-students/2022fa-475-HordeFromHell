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

    float elapsedTime = 0f;
    float passedTime = 0f;
    public float gainBullet = 15f;
	public float reloadTime;
    public int ammo = 50;
    public int maxAmmo = 200;

    void Update()
    {
	    if(pauseMenu.GetComponent<InGameMenus>().paused == false && pauseMenu.GetComponent<InGameMenus>().dead == false)
        {
            pauseMenu.GetComponent<DisplayAmmo>().UpdateAmmo(ammo);
            elapsedTime += Time.deltaTime;
            passedTime  += Time.deltaTime;

            if (Input.GetKey(KeyCode.Mouse0) && elapsedTime > reloadTime && ammo > 0)
            {   
                ammo--;
                GameObject bulletFake = Instantiate(looksBullet, viewEnd.transform.position, transform.rotation);
                Rigidbody bf = bulletFake.GetComponent<Rigidbody>();
                GameObject bullet = Instantiate(realBullet, fireEnd.transform.position, transform.rotation); 
                Rigidbody b = bullet.GetComponent<Rigidbody>();
                elapsedTime = 0f;
            }

            if(gainBullet < passedTime)
            {
                passedTime = 0f;
                addAmmo(1);
            }
        }
    }

    public void addAmmo(int x)
    {
        ammo += x;

        if(ammo > maxAmmo)
        {
            ammo = maxAmmo;
        }
    }
}
