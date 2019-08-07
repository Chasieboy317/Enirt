using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Knight uses WASD controls
 * Q to Push
 * E to jump 
 * R to slash
 * T to dual attack 
 * Z to walk
 * X to run
 */
public class KnightController : PlayerController
{
    /*bools in animator controller:
     * isWalking
     * isRunning
     * climbUp
     * isAttacking
     * jump
     * jumpingOnto
     * isPushing
     * slash
     * isDead 
     */
    
    // Start is called before the first frame update
    void Start() 
    {
        OnStart(); //base class (PlayerController)
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate(); //base class (PlayerController)


        /*
         * JUMPING
         */
        //jumping down
        if(Input.GetKey(KeyCode.Space)){
            animController.SetBool("jump", true);
            animController.SetBool("jumpingOnto", false);
        }
        //jumping onto
        /*else if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.W))
        {
            animController.SetBool("jump", true);
            animController.SetBool("jumpingOnto", true);
        }*/
        //not jumping
        else
        {
            animController.SetBool("jump", false);
        }
        /*
         * SLASH
         */
        if (Input.GetKey(KeyCode.R))
        {
            animController.SetBool("slash", true);
        }
        else
        {
            animController.SetBool("slash", false);
        }
        /*
         * DUAL ATTACK
         */
        if (Input.GetKey(KeyCode.T))
        {
            animController.SetBool("isAttacking", true);
        }
        else
        {
            animController.SetBool("isAttacking", false);
        }
        /*
         * PUSH
         */
        if (Input.GetKey(KeyCode.Q))
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
        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S))
        {
            //transform.Rotate(Vector3.up);
            animController.SetBool("isRunning", true);
        }
        else
        {
            animController.SetBool("isRunning", false);
        }
        if (Input.GetKey(KeyCode.Z)||Input.GetKey(KeyCode.X))
        {
            animController.SetBool("isWalking", true);
        }
        else
        {
            animController.SetBool("isWalking", false);
        }

        //transform.rotation = Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation;
        
        //transform.rotation = Quaternion.FromToRotation(transform.up,Vector3.up);
        //transform.eulerAngles.Set(transform.eulerAngles.x, 0f, transform.eulerAngles.z) = 0f;// = new Vector3(transform.eulerAngles.x, 0f,transform.eulerAngles.z);
    }
}
