using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (transform.gameObject.tag == "Knight" || transform.gameObject.tag == "Robot") SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (health>10)
        {
            health = 10;
        }
    }

}
