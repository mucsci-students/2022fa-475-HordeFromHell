using UnityEngine;
public class VelocityScript : MonoBehaviour
{
    Vector3 direction;
    public float speed = 10;
    public float bulletLife = 2f;
    float elapsedTime = 0f;
    public GameObject banghit;
    

    void Start()
    {
        direction = Camera.main.transform.forward;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        transform.position += direction * Time.deltaTime * speed;
        if (elapsedTime > bulletLife)
        {   
            Destroy (gameObject);
	        elapsedTime = 0f;
        }
    }

    void OnTriggerEnter (Collider collider) {
		GameObject collidedWith = collider.gameObject;
		if (collidedWith.tag == gameObject.tag) {
			Destroy (gameObject);
			Destroy (collidedWith);
            //GameObject bulletFake = Instantiate(banghit, gameObject.transform.position, transform.rotation);
                //Rigidbody bf = bulletFake.GetComponent<Rigidbody>();
		} else if (collidedWith.tag != "Gun" && collidedWith.tag != "Player" && collidedWith.tag != "MainCamera") {
            //GameObject bulletFake = Instantiate(banghit, gameObject.transform.position, transform.rotation);
                //Rigidbody bf = bulletFake.GetComponent<Rigidbody>();
                Destroy (gameObject);
		}
	}
}
