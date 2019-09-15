using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public int health;

    public void takeDamage(int d)
    {
        health -= d;

        if (health < 0)
        {
            //play destruction effect //haven't tested this yet
            if (this.transform.gameObject.GetComponent<ParticleSystem>())
            {
                this.transform.gameObject.GetComponent<ParticleSystem>().Play();
            }
            Destroy(this.gameObject);
            Debug.Log("Destroyed");
        }
        else if (health>10)
        {
            health = 10;
        }
    }

}
