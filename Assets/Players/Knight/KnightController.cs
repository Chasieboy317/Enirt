using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Knight uses WASD controls
 * Space+W to jump onto
 * Space+S to jump off
 * Q to Push
 * E to block 
 * R to slash
 * T to dual attack 
 */
public class KnightController : PlayerController
{
   
    //Key codes for actions unique to knight
    public KeyCode blocking;
    public KeyCode dualAttack;
    public KeyCode slash;

    // Start is called before the first frame update
    void Start() 
    {
        OnStart(); //base class (PlayerController)

        //UNLESS OTHERWISE CONFIGURED
        blocking = KeyCode.E;
        dualAttack = KeyCode.T;
        slash = KeyCode.R;
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate(); //base class (PlayerController)

        /*
         * SLASH
         */
        if (Input.GetKey(slash))
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
        if (Input.GetKey(dualAttack))
        {
            animController.SetBool("isAttacking", true);
        }
        else
        {
            animController.SetBool("isAttacking", false);
        }

        /*
         * Blocking
         */
        if (Input.GetKey(blocking))
        {
            animController.SetBool("isBlocking", true);
        }
        else
        {
            animController.SetBool("isBlocking", false);
        }

        //transform.rotation = Quaternion.FromToRotation(transform.up, Vector3.up) * transform.rotation;

        //transform.rotation = Quaternion.FromToRotation(transform.up,Vector3.up);
        //transform.eulerAngles.Set(transform.eulerAngles.x, 0f, transform.eulerAngles.z) = 0f;// = new Vector3(transform.eulerAngles.x, 0f,transform.eulerAngles.z);
    }
}
