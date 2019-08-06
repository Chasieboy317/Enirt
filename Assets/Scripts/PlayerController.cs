using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animController;
    public bool dead = false;
    public int health;

    //Added these variables so keycodes can be configured in options menu
    //Used cardinal directions because right/left etc are relative
    public KeyCode north;
    public KeyCode south;
    public KeyCode east;
    public KeyCode west;
    //keys for actions both players have
    public KeyCode push;
    public KeyCode jump;

    //toggle for walking/running
    public KeyCode toggle; //sets running true or false
    public bool running = false;

    // Start is called before the first frame update
    public void OnStart()
    {
        animController = GetComponent<Animator>();

        //Maybe use a variable to check whether configured or not?
        if(this.name == "Knight")
        {
            Debug.Log("knight should be moving");
            north = KeyCode.W;
            west = KeyCode.A;
            south = KeyCode.S;
            east = KeyCode.D;

            push = KeyCode.Q;
            jump = KeyCode.Space;

            toggle = KeyCode.LeftShift;
        }
        else if(this.name == "Robot")
        {
            north = KeyCode.UpArrow;
            west = KeyCode.RightArrow;
            south = KeyCode.DownArrow;
            east = KeyCode.LeftArrow;

            push = KeyCode.Question;
            jump = KeyCode.RightShift;

            toggle = KeyCode.KeypadEnter;
        }
    }

    // Update is called once per frame
    public void OnUpdate()
    {
        //Movements common to both
        /*
         * JUMPING
         */

        /*
        //jumping down
        if (Input.GetKey(jump) && Input.GetKey(south))
        {
            animController.SetBool("jump", true);
            animController.SetBool("jumpingOnto", false);
        }
        //jumping onto
        else if (Input.GetKey(jump) && Input.GetKey(north))
        {
            animController.SetBool("jump", true);
            animController.SetBool("jumpingOnto", true);
        }
        */
        if (Input.GetKey(jump))
        {
            if (transform.position.y == 0) //jump up
            {
                animController.SetBool("jump", true);
                animController.SetBool("jumpingOnto", true);
            }
            else
            {
                animController.SetBool("jump", true);
                animController.SetBool("jumpingOnto", false);
            }
        }
        //not jumping
        else
        {
            animController.SetBool("jump", false);
        }

        //4 directional turning
        //change direction
        //OBVIOUSLY TURNS ARE RELATIVE TO CAMERA SO DEPENDS HOW YOU SET UP CAMERA IF MAPPING IS LOGICAL
        if (Input.GetKey(north))
        {
            transform.eulerAngles = new Vector3(0f, 270f, 0f);
        }
        else if (Input.GetKey(west))
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if (Input.GetKey(south))
        {
            transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
        else if (Input.GetKey(east))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        /*
         * 360 rotation
        //Use right/D and left/W arrow keys to change player direction
        Vector2 keyInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        Vector2 inputDirection = keyInput.normalized;
        if (inputDirection != Vector2.zero)
        {
            transform.RotateAround(transform.position, Vector3.up, Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg * Time.deltaTime);
        }
        */

        //set toggle 
        if (Input.GetKey(toggle))
        {
            if (running)
            {
                running = false;
            }
            else
            {
                running = true;
            }
        }

        /*
         * PUSH
         */
        if (Input.GetKey(push))
        {
            animController.SetBool("isPushing", true);
        }
        else
        {
            animController.SetBool("isPushing", false);
        }
        /*
         * WALKING AND RUNNING
         */

        if (Input.GetKey(east) || Input.GetKey(west) || Input.GetKey(north) || Input.GetKey(south))
        {
            if (running)
            {
                animController.SetBool("isRunning", true);
                animController.SetBool("isWalking", false);
                if (Input.GetKey(jump))
                {
                    animController.SetBool("jumping", true);
                }
                else
                {
                    animController.SetBool("jumping", false);
                }
            }
            else
            {
                animController.SetBool("isWalking", true);
                animController.SetBool("isRunning", false);
            }
        }
        else
        {
            animController.SetBool("isRunning", false);
            animController.SetBool("isWalking", false);
        }

        /*
         * CHECK IF PLAYER DIES
         */
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
