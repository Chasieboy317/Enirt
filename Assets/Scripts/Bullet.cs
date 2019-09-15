﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > 2.5f)
        {
            Destroy(this.gameObject);
        }
    }
    

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
