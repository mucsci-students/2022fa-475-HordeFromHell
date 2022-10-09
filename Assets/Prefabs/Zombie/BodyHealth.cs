using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class BodyHealth : MonoBehaviour
{
    public float max_health = 1000f;
    public float cur_health = 1f;
    public bool alive = true;
    public Animator m_Animator;
    public bool legsDamaged;
    public Vector3 camera_Locale;
    public Camera m_Camera;
    public float playerDistance;
    public float speed;
    public Vector3 playerDirection;
    public GameObject healthbox;
    public GameObject ammobox;
    private float percentChanceToDropLoot = 20f;
    private float timeDelayForLoot = 0f;
    Rigidbody m_Rigidbody;
    public float gravityScale = 10.0f;
    public FirstPersonController FPC;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Camera = Camera.main;
        speed = Random.Range(3, 10);
        legsDamaged = false;
        cur_health = max_health;
        alive = true;
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 gravity = -9.81f * gravityScale * Vector3.up;
        m_Rigidbody.AddForce(gravity, ForceMode.Acceleration);
       
        if (alive)
        {
            playerDistance = Vector3.Distance(m_Camera.transform.position, gameObject.transform.position);
            playerDirection = m_Camera.transform.position - gameObject.transform.position;
            Vector3 zeroDirection = new Vector3(m_Camera.transform.position.x - gameObject.transform.position.x, 0, m_Camera.transform.position.z - gameObject.transform.position.z);
            Vector3 zeroCamera = new Vector3(m_Camera.transform.position.x, gameObject.transform.position.y, m_Camera.transform.position.z);
            
            if (playerDistance > 40)
            {
                transform.LookAt(zeroCamera);
                m_Animator.SetTrigger("playerFar");
                move(speed, zeroDirection);
            }
            else if (playerDistance < 3)
            {
                transform.LookAt(zeroCamera);
                m_Animator.SetTrigger("attack");
                
               move(speed*2, zeroDirection);
               if (playerDistance < 2.3) {
                move(speed /100, zeroDirection);
               }
            } else
            {
                transform.LookAt(zeroCamera);
                m_Animator.SetTrigger("playerNear");
               move(speed*2, zeroDirection);
            }
            

        } else
        {
            speed = 0;
             m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY |
        RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        }

    }



    void move(float movementSpeed, Vector3 playerDirection)
    {
        movementSpeed = movementSpeed / 50;
        transform.position = transform.position + new Vector3(playerDirection.x*movementSpeed* Time.deltaTime, 0, playerDirection.z*movementSpeed * Time.deltaTime);
    }

    public void legsDamage()
    {
        if (legsDamaged)
            return;
        legsDamaged = true;
        speed = speed / 2;
    }


    public void OnChildTriggerEnter(bool headAlive, float damage, bool legsAlive)
    {
        //Debug.Log(damage);
        if (!alive)
            return;
        cur_health -= damage;
        if (cur_health < 0 || !headAlive)
        {
            if(!headAlive)
            {
                FPC.GetComponent<Score>().score += 100;
            }
            else
            {
                FPC.GetComponent<Score>().score += 50;
            }

            GameObject canvas = GameObject.Find("Canvas");
            Transform textTr = canvas.transform.Find("ScoreText");
            textTr.GetComponent<TextMeshProUGUI>().text = "Score: " + FPC.GetComponent<Score>().score;

            cur_health = 0;
            alive = false;
            int death = Random.Range(1, 3);
            if (death >=2)
                m_Animator.SetTrigger("death2");
            else
                m_Animator.SetTrigger("death1");

            Rigidbody m_Rigidbody = GetComponent<Rigidbody>();

            Invoke("dropLoot", timeDelayForLoot);
            Destroy(gameObject, 5f);

        }
        if (alive && !legsAlive)
            legsDamage();
    }

    public void dropLoot() {
        if (Random.Range(0f,100f)<=percentChanceToDropLoot)
            {
                GameObject go;
                if (Random.Range(-10f,10f) >=0) {
                    go = Instantiate(ammobox);
                } else {
                    go = Instantiate(healthbox);
                }
                go.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+1, gameObject.transform.position.z);
                Destroy(go, 20f);
            }
    }

}
