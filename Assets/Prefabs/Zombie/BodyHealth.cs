using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
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

        if (alive)
        {
            playerDistance = Vector3.Distance(m_Camera.transform.position, gameObject.transform.position);
            playerDirection = m_Camera.transform.position - gameObject.transform.position;
            Vector3 zeroDirection = new Vector3(m_Camera.transform.position.x - gameObject.transform.position.x, gameObject.transform.position.y, m_Camera.transform.position.z - gameObject.transform.position.z);
            Vector3 zeroCamera = new Vector3(m_Camera.transform.position.x, gameObject.transform.position.y, m_Camera.transform.position.z);
            Debug.Log(playerDistance);
            
            if (playerDistance > 200)
            {
                transform.LookAt(zeroCamera);
              }
            else if (playerDistance > 40)
            {
                transform.LookAt(zeroCamera);
                m_Animator.SetTrigger("playerFar");

                move(speed, zeroDirection);
            }
            else if (playerDistance < 2)
            {
                transform.LookAt(zeroCamera);
                m_Animator.SetTrigger("attack");
                move(speed /20, zeroDirection);
            } else
            {
                transform.LookAt(zeroCamera);
                m_Animator.SetTrigger("playerNear");
               move(speed*2, zeroDirection);
            }
            

        } else
        {
            speed = 0;
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
            cur_health = 0;
            alive = false;
            int death = Random.Range(1, 2);
            if (death == 1)
                m_Animator.SetTrigger("death1");
            else
                m_Animator.SetTrigger("death2");

            Rigidbody m_Rigidbody = GetComponent<Rigidbody>();
            m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionX;
            m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
            m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;
        }
        if (alive && !legsAlive)
            legsDamage();
    }



}
