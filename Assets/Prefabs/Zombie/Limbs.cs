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
    public float coolDownBetweenAttacks = 2f;
    public GameObject player;
    public float zombieHealth;
    public bool attack = true;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("FPSController");
        parent = getGrandparent(gameObject).GetComponent<BodyHealth>();
        cur_health = max_health;
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getGrandparent(GameObject input) {
        if (input.transform.parent == null)
            return input;
        return getGrandparent(input.transform.parent.gameObject);
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


    public void OnTriggerEnter(Collider aCol)
    {
        if (aCol == null)
            return;
            
        if (aCol.name == "RealBullet Variant(Clone)")
        {
            Vector3 closestPoint = aCol.ClosestPointOnBounds(transform.position);
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, transform.forward);
            GameObject go = Instantiate(skinImpact, closestPoint, rot);
            Destroy(go, .3f);

            float damage = Random.Range(350, 600);
            TakeDamage(damage);
            //Debug.Log(damage);
        }
        
        zombieHealth = parent.GetComponent<BodyHealth>().cur_health;

        if (zombieHealth <= 0)
            return;

         if (aCol.name == "FPSController" && attack && (gameObject.name == "Z_L_ArmPalm" || gameObject.name == "Z_R_ArmPalm"))
            {
            var component = player.GetComponent<PlayerHealth>();
            component.TakeDamage(10);
            attack = false;
            Invoke("cooldown", coolDownBetweenAttacks);
            }

    }

    void cooldown() {
        attack = true;
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
