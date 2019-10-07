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

    //Audio effects
    public AudioClip dualAttackSound;
    public AudioClip slashSound;

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
            //sound effect
            if (!audioSource.isPlaying)
            {
                audioSource.loop = false;
                audioSource.clip = slashSound;
                audioSource.Play();
            }
            //movement
            animController.SetBool("slash", true);
            swordCollider.SetActive(true);

        }
        else
        {
            animController.SetBool("slash", false);
            if (Time.time > startSlash + slashTime && Time.time > startAttack + attackTime)
            {
                swordCollider.SetActive(false);
                if (audioSource.clip == slashSound) { audioSource.clip = null; audioSource.loop = true; }
            }
        }
        /*
         * DUAL ATTACK
         */
        if (Input.GetKey(dualAttack))
        {
            startAttack= Time.time;
            //sound effect
            if (!audioSource.isPlaying)
            {
                audioSource.loop = false;
                audioSource.clip = dualAttackSound;
                audioSource.Play();
            }
            //movement
            animController.SetBool("isAttacking", true);
            swordCollider.SetActive(true);
        }
        else
        {
            animController.SetBool("isAttacking", false);
            if(Time.time > startAttack + attackTime && Time.time > startSlash + slashTime)
            {
                swordCollider.SetActive(false);
                if (audioSource.clip == dualAttackSound) { audioSource.clip = null; audioSource.loop = true; }
            }
        }

        /*
         * Blocking
         */
        if (Input.GetKey(blocking))
        {
            animController.SetBool("isBlocking", true);
            this.transform.gameObject.GetComponent<Destructable>().enabled = false;
        }
        else
        {
            animController.SetBool("isBlocking", false);
            this.transform.gameObject.GetComponent<Destructable>().enabled = true;

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
