using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public Rigidbody bullet;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        damage = 2;

        this.GetComponent<Rigidbody>().velocity = bulletSpeed * transform.forward;
    }

    /* Update is called once per frame
    void Update()
    {
        
    }
    */

    private void OnCollisionEnter(Collision collision)
    {
        //send damage message to collision
        if (collision.transform.gameObject.GetComponent("Destructible"))
        {
            collision.transform.gameObject.SendMessage("takeDamage", damage);
        }
        Destroy(this.gameObject);
    }
}
