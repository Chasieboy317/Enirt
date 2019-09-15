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

    public float startSlash;
    public float slashTime = 1.15f;
    public float startAttack;
    public float attackTime = 3.16f;

    public GameObject swordCollider;

    // Start is called before the first frame update
    void Start() 
    {
        SetControls();

        swordCollider.SetActive(false);
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

        //reset boxColCenter
        if (Time.time > runJumpStart + runJumpTime && boxCollider.center.y != boxColCenter.y)
        {
            boxCollider.center = boxColCenter;
            rigBody.useGravity = true;
        }
        /*
         * SLASH
         */
        if (Input.GetKey(slash))
        {
            startSlash = Time.time;
            animController.SetBool("slash", true);
            swordCollider.SetActive(true);

        }
        else
        {
            animController.SetBool("slash", false);
            if (Time.time > startSlash + slashTime && Time.time > startAttack + attackTime)
            {
                swordCollider.SetActive(false);
            }
        }
        /*
         * DUAL ATTACK
         */
        if (Input.GetKey(dualAttack))
        {
            startAttack= Time.time;
            animController.SetBool("isAttacking", true);
            swordCollider.SetActive(true);
        }
        else
        {
            animController.SetBool("isAttacking", false);
            if(Time.time > startAttack + attackTime && Time.time > startSlash + slashTime)
            {
                swordCollider.SetActive(false);
            }
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
