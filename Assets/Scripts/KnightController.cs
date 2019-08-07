using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Knight uses WASD controls
 * Q to Push
 * SPACE to jump 
 * R to slash
 * T to dual attack 
 * Z or X to walk
 * A or D to run
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
        //jumping
        if(Input.GetKey(KeyCode.Space)){
            animController.SetBool("jump", true);
            animController.SetBool("jumpingOnto", false);
        }
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
<<<<<<< HEAD:Assets/Players/Knight/KnightController.cs
        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S))
        {
            //transform.Rotate(Vector3.up);
=======
        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.W))
        {
>>>>>>> bf0a7fe78c429a46125d8e84e77598c01c913db8:Assets/Scripts/KnightController.cs
            animController.SetBool("isRunning", true);
        }
        else
        {
            animController.SetBool("isRunning", false);
        }
<<<<<<< HEAD:Assets/Players/Knight/KnightController.cs
        if (Input.GetKey(KeyCode.Z)||Input.GetKey(KeyCode.X))
=======
        if ((Input.GetKey(KeyCode.Z)) || Input.GetKey(KeyCode.X))
>>>>>>> bf0a7fe78c429a46125d8e84e77598c01c913db8:Assets/Scripts/KnightController.cs
        {
            animController.SetBool("isWalking", true);
        }
        else
        {
            animController.SetBool("isWalking", false);
        }
    }
}
