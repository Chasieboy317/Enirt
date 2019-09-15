using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is for use in level 3
//Alien ship torpedo desceneds and then heads for chest height of robot doppelganger
public class alienShipTorpedo : LockTarget
{
    // Start is called before the first frame update
    public GameObject target;
    public float damage = 2f;
    public float fireTime;
    
    void Start()
    {
        target = getTarget("Robot", "RobotDoppelgangerScript");
        fireTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > target.transform.position.y + 1.2f)
        {
            this.transform.position = new Vector3( this.transform.position.x, this.transform.position.y - (3f * Time.deltaTime), this.transform.position.z);
            this.transform.position = this.transform.position + this.transform.forward * 1f * Time.deltaTime;
        }
        else
        {
            this.transform.position = this.transform.position + this.transform.forward * 3f * Time.deltaTime;
        }

        if(target == null || Time.time - fireTime > 5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("On Collision Enter");
        //send damage message to collision
        if (collision.transform.gameObject.GetComponent("Destructable"))
        {
            collision.transform.gameObject.SendMessage("takeDamage", damage);
        }
        Destroy(this.gameObject);
    }
}
