
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animController;
    public Rigidbody rigBody;
    public BoxCollider boxCollider;

    public bool dead = false;
    public int health =10;

    //This will be used to determine whether 'jump' should be enabled for the player
    public string climbableTag;
    public float climableMaxDixtance;
    public float climableMinDistance;
    public float climbTime;
    public float climbStartTime;
    public float jumpDownTime = 0.5f;

    //for running jump
    public Vector3 runJumpBoxColCenter = new Vector3(0,2f,0.35f);
    public Vector3 boxColCenter = new Vector3(0,1,0.35f);
    public float runJumpStart;
    public float runJumpTime = 0.6f;
    public bool justJumped = false;

    //Added these variables so keycodes can be configured in options menu
    //Used cardinal directions because right/left etc are relative
    public KeyCode north;
    public KeyCode south;
    public KeyCode east;
    public KeyCode west;
    //keys for actions both players have
    public KeyCode push;
    public KeyCode jump;
    public KeyCode pullLever;

    //toggle for walking/running
    public KeyCode toggle; //sets running true or false
    public bool running = false;

    //Sound effects
    public AudioClip runningClip;
    public AudioClip walkingClip;

    //private Component[] audioSources;
    //private AudioSource runningSource;
    //private AudioSource walkingSource;
    public AudioSource audioSource;
    // Start is called before the first frame update
    public void OnStart()
    {
        animController = GetComponent<Animator>();
        rigBody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();

        //audioSources = GetComponents(typeof(AudioSource));
        //runningSource = (AudioSource)audioSources[0];
        //walkingSource = (AudioSource)audioSources[1];
        //Debug.Log(runningSource +""+ walkingSource);
        //runningSource.clip = runningClip; walkingSource.clip = walkingClip;
        audioSource = GetComponent<AudioSource>();

        //Maybe use a variable to check whether configured or not?
        if(this.tag == "Knight")
        {
            north = KeyCode.W;
            west = KeyCode.A;
            south = KeyCode.S;
            east = KeyCode.D;

            push = KeyCode.Q;
            jump = KeyCode.Space;
            pullLever = KeyCode.Z;

            toggle = KeyCode.LeftShift;

            climbableTag = "KnightJumpOnto";
            climableMaxDixtance = 1.8f;
            climableMinDistance = 0.5f;
            climbTime = 2.1f;
        }
        else// if(this.tag == "Robot")
        {
            north = KeyCode.UpArrow;
            west = KeyCode.LeftArrow;
            south = KeyCode.DownArrow;
            east = KeyCode.RightArrow;

            push = KeyCode.I;//KeyCode.Question;
            jump = KeyCode.RightShift;
            pullLever = KeyCode.K;

            toggle = KeyCode.L; //KeyCode.KeypadEnter

            climbableTag = "RobotClimbOnto";
            climableMaxDixtance = 1.5f;
            climableMinDistance = 0.5f; 
            climbTime = 4.1f;
        }
    }

    // Update is called once per frame
    public void OnUpdate()
    {
        if (this.transform.position.y < 0)
        {
            this.transform.position = new Vector3(this.transform.position.x,0,this.transform.position.z);
        }

        //Movements common to both
        /*
         * JUMPING
         */

        if (Input.GetKey(jump)) //!running && Input.GetKey(jump)
        {
            //only enable jump if it is an object the player can jump onto 
            Vector3 direction = this.transform.forward;
            Vector3 start = this.transform.position + new Vector3(0,0.5f,0) + 0.5f * direction;

            RaycastHit hit;
            if (Physics.Raycast(start, direction, out hit))
            {
                Debug.DrawRay(start, direction * 10, Color.green);
                Debug.Log(hit.transform.tag);

                float distance = Vector3.Distance(hit.point, transform.position);
                Debug.Log(distance);
                if (climbableTag == hit.transform.tag && distance >= climableMinDistance && distance <= climableMaxDixtance) //climbable object
                {
                    rigBody.useGravity = false;
                    climbStartTime = Time.time;
                    boxCollider.enabled = false;
                        
                    animController.SetBool("jump", true);
                    animController.SetBool("jumpingOnto", true);
                    
                }
                //hit.collider.gameObject.SetActive(false);
            }
            /*
            else
            {
                
                if (this.transform.position.y >= 0.5)
                {
                    animController.SetBool("jump", true);
                    animController.SetBool("jumpingOnto", false);
                }
            }
            */
        }
        //renable box collider when jump time has passed
        else if (!boxCollider.enabled && Time.time - climbStartTime > climbTime)
        {
            boxCollider.enabled = true;
            rigBody.useGravity = true;
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
            transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }
        else if (Input.GetKey(west))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (Input.GetKey(south))
        {
            transform.eulerAngles = new Vector3(0f, 270f, 0f);
        }
        else if (Input.GetKey(east))
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
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
            running = running ? false : true;
        }

        /*
         * PUSH
         */
        if (Input.GetKey(push))
        {
            Vector3 dir = this.transform.forward;
            Vector3 startPos = this.transform.position + new Vector3(0, 0.3f, 0) + 0.3f*dir;
            
            RaycastHit hitObj;
            if (Physics.Raycast(startPos, dir, out hitObj))
            {
                float dist = Vector3.Distance(hitObj.point, transform.position);
                Debug.DrawRay(startPos, dir * 10, Color.red);
                Debug.Log("push distance "+dist);
                Debug.Log(hitObj.transform.gameObject.GetComponent("Pushable") != null);
                if (dist <= 15f && hitObj.transform.gameObject.GetComponent("Pushable") != null) //dist changed from 3.3f
                {
                    
                    Debug.Log("transform.forward" + dir);
                    hitObj.transform.gameObject.GetComponent("Pushable").SendMessage("wasPushed", dir);
                    animController.SetBool("isPushing", true);                    
                }
                //code for turnstile Level 3 (doesn't affect anything else)
                GameObject turnstile = hitObj.transform.parent.gameObject;
                if (dist <=3.3f && turnstile.GetComponent("Turnstile")!=null)//hitObj.transform.gameObject.GetComponentInParent("Turnstile") != null)
                {
                    turnstile.GetComponent("Turnstile").SendMessage("playerPushing", 1);
                    animController.SetBool("isPushing", true);
                }
            }
        }
        else
        {
            animController.SetBool("isPushing", false);
        }

        /*
         * PULL LEVER
         */

        if (Input.GetKey(pullLever))
        {
            RaycastHit lever;
            Debug.DrawRay(this.transform.position + new Vector3(0, 0.7f, 0), transform.forward);
            if(Physics.Raycast(this.transform.position + new Vector3(0, 0.7f, 0), transform.forward,out lever))
            {
                //Debug.Log("Lever raycast hit");
                //Debug.Log(lever.transform.gameObject.GetComponent<lever>() != null);
                //Debug.Log(lever.transform.gameObject.tag == "lever");
                if((lever.transform.gameObject.GetComponent("lever")!=null || lever.transform.gameObject.GetComponent("myLever")!=null ) && Vector3.Distance(lever.point, transform.position + new Vector3(0, 1, 0)) < 1.0f)
                {
                    //Debug.Log("In Lever if");
                    //Debug.Log(lever.transform.gameObject.GetComponent<lever>()!=null);
                    lever.transform.gameObject.GetComponent<lever>().activated = true;
                    animController.SetBool("pullLever", true);
                }
            }
        }
        else
        {
            animController.SetBool("pullLever",false);
        }

        /*
         * WALKING AND RUNNING
         */

        if (Input.GetKey(east) || Input.GetKey(west) || Input.GetKey(north) || Input.GetKey(south))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            if (running)
            {
                audioSource.clip = runningClip;

                animController.SetBool("isRunning", true);
                animController.SetBool("isWalking", false);

                if (Input.GetKey(jump))
                {
                    runJumpStart = Time.time;
                    rigBody.useGravity = false;
                    boxCollider.center = runJumpBoxColCenter;
                    animController.SetBool("jump", true);
                }
                else
                {
                    animController.SetBool("jump", false);

                    if (Time.time > runJumpStart + runJumpTime)
                    {
                        boxCollider.center = boxColCenter;
                        rigBody.useGravity = true;
                    }

                }
            }
            else
            {
                //runningSource.Stop();
                //if (!walkingSource.isPlaying) walkingSource.Play();
                audioSource.clip = walkingClip;
                //audioSource.Play();

                animController.SetBool("isWalking", true);
                animController.SetBool("isRunning", false);
            }
        }
        /*
         * Was trying to debug running jump but then it just gave crawling bugs
        if(Input.GetKey(jump) && running)
        {
            if (!justJumped)
            {
                justJumped = true;
                runJumpStart = Time.time;
                rigBody.useGravity = false;
                //rigBody.AddForce(transform.up);
                boxCollider.center = runJumpBoxColCenter;
                animController.SetBool("jump", true);
            }
        }
        else if (running)
        {
            animController.SetBool("isRunning", true);
            animController.SetBool("isWalking", false);
            if (justJumped && Time.time > runJumpStart + runJumpTime + 0.3f)
            {
                justJumped = false;
            }
            else if (Time.time > runJumpStart + runJumpTime)
            {
                boxCollider.center = boxColCenter;
                rigBody.useGravity = true;
            }
            animController.SetBool("jump", false);
        }
        else
        {
            animController.SetBool("isWalking", true);
            animController.SetBool("isRunning", false);
        }
        */

    
        else
        {
            //runningSource.Stop();
            //walkingSource.Stop();
            audioSource.Stop();
            animController.SetBool("isRunning", false);
            animController.SetBool("isWalking", false);
            //animController.SetBool("jump", false);
        }

        /*
        if (justJumped && Time.time > runJumpStart + runJumpTime + 0.3f)
        {
            justJumped = false;
        }
        else if (Time.time > runJumpStart + runJumpTime)
        {
            boxCollider.center = boxColCenter;
            rigBody.useGravity = true;
        }
        */
        /*
         * CHECK IF PLAYER DIES
         * move to Destructable?
         
        if (!dead && health <= 0)
        {
            Debug.Log("isDead set");
            animController.SetBool("isDead", true);
            dead = true;
            //animController.SetBool("isDead", false);
        }
        */

    }

    void TakeDamage(int amount)
    {
        health -= amount;
        if (health<=0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("player died");
        animController.SetBool("isDead", true);
    }

}

