using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Laser Bullet for Robot's gun
//Applies force to RigidBody 

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public Rigidbody bullet;
    public int damage;

    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        damage = 2;
        startTime = Time.time;
        this.GetComponent<Rigidbody>().velocity = bulletSpeed * transform.forward;
    }


    //Destroy the bullet after a certain time
    void Update()
    {
        if (Time.time - startTime > 2.5f)
        {
            Destroy(this.gameObject);
        }
    }
    
    //On Collision with another object - if destructable script attached, takeDamage will decrement the health
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag!="Robot")
        {
            //send damage message to collision
            if (collision.transform.gameObject.GetComponent("Destructable"))
            {
                collision.transform.gameObject.SendMessage("takeDamage", damage);
            }
            Destroy(this.gameObject);
        }
        
    }
}
