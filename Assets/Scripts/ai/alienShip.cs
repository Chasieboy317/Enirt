using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienShip : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject torpedoPrefab;
    public float fireRate = 10f;
    public float fireTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > fireTime + fireRate)
        {
            fireTime = Time.time;
            Instantiate(torpedoPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("torpedo instantiated");
        
        }
    }
}
