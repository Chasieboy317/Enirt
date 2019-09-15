using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Planning to use this in level 3 doppelganger battle
//Ship targets the RobotDoppelganger
public class alienShip : LockTarget
{
    public Transform spawnPoint;
    public GameObject torpedoPrefab;
    public float fireRate = 30f;
    public float fireTime;

    public GameObject[] robots;
    public GameObject target; //in level 3 this will be the robot doppelganger

    public float maxY;
    public float minY;
    public float deltaY = 3f;
    public bool up;

    public float lastRandomDir;
    public float dirChangeTime = 12f;
    public bool clockwise;

    public float targetDistance;

    // Start is called before the first frame update
    void Start()
    {
        target = getTarget("Robot", "RobotDoppelgangerScript");

        maxY = this.transform.position.y;
        minY = maxY - deltaY;
        up = false;
        clockwise = true;

        targetDistance = Vector3.Distance(this.transform.position, target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.time > fireTime + fireRate && target!=null)
        {
            fireTime = Time.time;
            Instantiate(torpedoPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("torpedo instantiated");
        
        }
        //randomly assign clockwise or anticlockwise movement
        if(Time.time > lastRandomDir + dirChangeTime)
        {
            if (Random.value > 0.5f)
            {
                clockwise = true;
            }
            else
            {
                clockwise = false;
            }
            lastRandomDir = Time.time;
        }
        if (clockwise && target!=null) // rotate around doppelganger clockwise
        {
            this.transform.RotateAround(target.transform.position, Vector3.up, 5 * Time.deltaTime);
        }
        else if (target!=null) //rotate around doppelganger anticlockwise 
        {
            this.transform.RotateAround(target.transform.position, Vector3.up, -5 * Time.deltaTime);
        }
        if (target != null)
        {
            Vector3 delta = this.transform.position - target.transform.position;
            //delta.y = 0; // Keep same Y level
            this.transform.position = target.transform.position + delta.normalized * targetDistance;
            this.transform.LookAt(new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z));
        }
        
        //move the ship up or down between min and max y
        if (up)
        {
            if(this.transform.position.y < maxY)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + deltaY * 0.3f * Time.deltaTime, this.transform.position.z);
            }
            else
            {
                up = false;
            }
        }
        else
        {
            if (this.transform.position.y > minY)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - deltaY * 0.3f * Time.deltaTime, this.transform.position.z);
            }
            else
            {
                up = true;
            }
        }
        
    }

}
