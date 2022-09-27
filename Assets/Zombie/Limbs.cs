using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Limbs : MonoBehaviour
{
    public float max_health = 100f;
    public float cur_health = 0f;
    private BodyHealth parent;
    public bool alive = true;
    public bool legsAlive = true;
    public GameObject skinImpact;


    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.GetComponent<BodyHealth>();
        cur_health = max_health;
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(float amount)
    {
        if (cur_health > 0)
        {
            cur_health -= amount;
            if (cur_health <= 0)
            {
                Destruction();
            }
        }
        parent.OnChildTriggerEnter(alive, amount, legsAlive);
    }

    //public void BloodSplash(Vector3 contactPoint, Quaternion rot)
    //{
         //   ContactPoint contact = collision.contacts[0];
       //     Vector3 pos = contact.point;
     //       Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
    //        Instantiate(skinImpact, pos, rot);

    //}


    public void OnTriggerEnter(Collider aCol)
    {
        if (aCol.name == "RealBullet Variant")
        {
            //Vector3 closestPoint = aCol.ClosestPointOnBounds(transform.position);
            //Quaternion rot = Quaternion.FromToRotation(Vector3.up, aCol.normal);
            //Instantiate(skinImpact, closestPoint, rot);

            float damage = Random.Range(1, 15);
            TakeDamage(damage);
            //Debug.Log(damage);
        }
    }

    public void Destruction()
    {
        switch(gameObject.name)
        {
            case "Z_R_LegThigh":
                legsAlive = false;
                break;
            case "Z_R_LegCalf":
                legsAlive = false;
                break;
            case "Z_L_LegThigh":
                legsAlive = false;
                break;
            case "Z_L_LegCalf":
                legsAlive = false;
                break;
            case "Z_Head":
                alive = false;
                Destroy(gameObject);
                break;
            case "Z_L_Upperarm":
                Destroy(gameObject);
                break;
            case "Z_L_Forearm":
                Destroy(gameObject);
                break;
            case "Z_L_ArmPalm":
                Destroy(gameObject);
                break;
            case "Z_R_Upperarm":
                Destroy(gameObject);
                break;
            case "Z_R_Forearm":
                Destroy(gameObject);
                break;
            case "Z_R_ArmPalm":
                Destroy(gameObject);
                break;
        }
    }
}
