using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Basic Script that is shared among all enemmies share. 
 **/

public class enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public float speed;

    public Rigidbody myRB; // 自分の剛体

    void Start() {
        myRB = GetComponent<Rigidbody>();
    }
    // OnCollisionEnter runs whenever a collision is detected (Collidors overlap). 
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "player") { // place holder. i dont know the tags right now, and am too lazy to check.
            other.gameObject.GetComponent<Destructable>().takeDamage(damage); // More placeholder code
            Debug.Log(other + "collided with player");
        }
    }
}
