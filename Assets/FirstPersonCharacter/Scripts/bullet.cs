using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class bullet : MonoBehaviour
{
    public GameObject realBullet;
    public GameObject looksBullet;
	public GameObject viewEnd;
    public GameObject fireEnd;
    public Canvas pauseMenu;
	public float reloadTime;
    float elapsedTime = 0f;
    public int ammo;

    void Start() {
        ammo = 30;
    }

    void Update()
    {
        
	    if(pauseMenu.GetComponent<InGameMenus>().paused == false)
        {
            pauseMenu.GetComponent<DisplayAmmo>().UpdateAmmo(ammo);
            elapsedTime += Time.deltaTime;
            if (Input.GetKey(KeyCode.Mouse0) && (elapsedTime > reloadTime) && ammo > 0)
            {   
                ammo--;
                GameObject bulletFake = Instantiate(looksBullet, viewEnd.transform.position, transform.rotation);
                Rigidbody bf = bulletFake.GetComponent<Rigidbody>();
                GameObject bullet = Instantiate(realBullet, fireEnd.transform.position, transform.rotation); 
                Rigidbody b = bullet.GetComponent<Rigidbody>();
                elapsedTime = 0f;
            }
        }
    }

    public void addAmmo(int x) {
        ammo += x;
    }
}
