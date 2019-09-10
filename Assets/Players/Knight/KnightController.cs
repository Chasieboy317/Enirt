using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : PlayerController
{
    public int damage = 2;
    //Key codes for actions unique to knight
    public KeyCode blocking;
    public KeyCode dualAttack;
    public KeyCode slash;

    // Start is called before the first frame update
    void Start() 
    {
        SetControls();
    }

    public void SetControls()
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
        playerMovement();
    }

    public void playerMovement()
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

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != "Knight" && other.transform.gameObject.GetComponent("Destructable"))
        {
            other.transform.gameObject.SendMessage("takeDamage", damage);
        }

    }
}
