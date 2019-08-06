using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public Animator animController;
    public Animator animController;
    public bool dead = false;
    public int health;

    // Start is called before the first frame update
    public void OnStart()
    {
        animController = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void OnUpdate()
    {
        //Use right/D and left/W arrow keys to change player direction
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if (Input.GetKey(KeyCode.X))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.Z))
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.eulerAngles = new Vector3(0f, 270f, 0f);
        }

        //Player dies
        else if (!dead && health <= 0)
        {
            dead = true;
            Debug.Log("isDead set");
            animController.SetBool("isDead", true);
        }

        
    }

    //function used to decrease health. Can be called from onTriggerEnter or something
    void takeDamage()
    {
        health -= 1;
    }
}
