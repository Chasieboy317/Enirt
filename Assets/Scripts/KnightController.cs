﻿using System.Collections;
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
public class KnightController : PlayerController {
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
    void Start() {
        OnStart(); //base class (PlayerController)
    }

    // Update is called once per frame
    void Update() {
        OnUpdate(); //base class (PlayerController)
        /*
         * JUMPING
         */
        //jumping
        if (Input.GetKey(KeyCode.Space)) {
            animController.SetBool("jump", true);
            animController.SetBool("jumpingOnto", false);
        }
        //not jumping
        else {
            animController.SetBool("jump", false);
        }
        /*
         * SLASH
         */
        if (Input.GetKey(KeyCode.R)) {
            animController.SetBool("slash", true);
        } else {
            animController.SetBool("slash", false);
        }
        /*
         * DUAL ATTACK
         */
        if (Input.GetKey(KeyCode.T)) {
            animController.SetBool("isAttacking", true);
        } else {
            animController.SetBool("isAttacking", false);
        }
        /*
         * PUSH
         */
        if (Input.GetKey(KeyCode.Q)) {
            animController.SetBool("isPushing", true);
        } else {
            animController.SetBool("isPushing", false);
        }
        /*
         * WALKING AND RUNNING
         */
    }
}
