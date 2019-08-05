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
        Vector2 keyInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        Vector2 inputDirection = keyInput.normalized;
        if (inputDirection != Vector2.zero)
        {
            transform.RotateAround(transform.position, Vector3.up, Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg * Time.deltaTime);
        }

        //Player dies
        if (!dead && health <= 0)
        {
            Debug.Log("isDead set");
            animController.SetBool("isDead", true);
            dead = true;
            //animController.SetBool("isDead", false);
        }

        
    }

    //function used to decrease health. Can be called from onTriggerEnter or something
    void takeDamage()
    {
        health -= 1;
    }
}
