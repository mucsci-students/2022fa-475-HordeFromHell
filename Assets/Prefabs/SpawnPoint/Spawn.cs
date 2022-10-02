using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject zombie;
    public GameObject hellgate;
    private float minTimeToSpawn = 3f;
    private float maxTimeToSpawn = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("spawnZombie", Random.Range(minTimeToSpawn, maxTimeToSpawn));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnZombie() {
        GameObject go = Instantiate(zombie);
        go.transform.position = gameObject.transform.position;
        GameObject ex = Instantiate(hellgate);
        ex.transform.position = gameObject.transform.position;
        Destroy(ex, 3f);
        Invoke("spawnZombie", Random.Range(minTimeToSpawn, maxTimeToSpawn));
        
    }
}
