using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Attach to any object you wish to be destructable
 * Player and enemy weapons send messages to this script and so can destroy objects with this script 
 * health can be set in the inspector
 */
public class Destructable : MonoBehaviour
{
    public int health;

    public void takeDamage(int d)
    {
        health -= d;

        if (health <= 0)
        {
            //play destruction effect if it exists
            if (this.transform.gameObject.GetComponent<ParticleSystem>())
            {
                this.transform.gameObject.GetComponent<ParticleSystem>().Play();
            }
            Destroy(this.gameObject);
            //Debug.Log("Destroyed");
            //if (transform.gameObject.tag == "Knight" || transform.gameObject.tag == "Robot") SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (health>10)
        {
            health = 10;
        }
    }

}
