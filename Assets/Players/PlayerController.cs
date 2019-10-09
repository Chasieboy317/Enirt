
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * PlayerController encapsulates all logic for actions common to both players: walking, running, running jump, climbing/jumping, pushing and pulling levers
 * RayCastHits are used to determine if the action is available for the intended object before the action is enabled
 * 
 */
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
    public AudioSource audioSource;


    // Start is called before the first frame update
    //On start assign keys based on the player
    public void OnStart()
    {
        animController = GetComponent<Animator>();
        rigBody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();

        audioSource = GetComponent<AudioSource>();

        //Assign keys for Knight
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
        //Assign keys for Robot
        else// if(this.tag == "Robot")
        {
            north = KeyCode.UpArrow;
            west = KeyCode.LeftArrow;
            south = KeyCode.DownArrow;
            east = KeyCode.RightArrow;

            push = KeyCode.I;
            jump = KeyCode.RightShift;
            pullLever = KeyCode.K;

            toggle = KeyCode.L; 

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

        if (Input.GetKey(jump)) 
        {
            
            Vector3 direction = this.transform.forward;
            Vector3 start = this.transform.position + new Vector3(0,0.5f,0) + 0.5f * direction;

            //only enable jump if it is an object the player can jump onto 
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
            }
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

        //if toggle key is pressed change between running and walking
        if (Input.GetKeyDown(toggle))
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

            //only enable push if it is an object with Pushable script attached
            RaycastHit hitObj;
            if (Physics.Raycast(startPos, dir, out hitObj))
            {
                float dist = Vector3.Distance(hitObj.point, transform.position);
                Debug.DrawRay(startPos, dir * 10, Color.red);
                Debug.Log("push distance "+dist);
                Debug.Log(hitObj.transform.gameObject.GetComponent("Pushable") != null);
                if (dist <= 15f && hitObj.transform.gameObject.GetComponent("Pushable") != null) 
                {
                    hitObj.transform.gameObject.GetComponent("Pushable").SendMessage("wasPushed", dir); //send message to pushable script
                    animController.SetBool("isPushing", true);                    
                }
                //code for turnstile Level 3 
                GameObject turnstile = hitObj.transform.parent.gameObject;
                if (dist <=3.3f && turnstile.GetComponent("Turnstile")!=null)
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
            //only enable pull lever if it is an object with lever script attached
            RaycastHit lever;
            if(Physics.Raycast(this.transform.position + new Vector3(0, 0.3f, 0) +0.3f*transform.forward, transform.forward,out lever))
            {
                Debug.Log(lever.transform.gameObject.tag);
                if((lever.transform.gameObject.GetComponent("lever")!=null || lever.transform.gameObject.GetComponent("myLever")!=null ) && Vector3.Distance(lever.point, transform.position + new Vector3(0, 1, 0)) < 1.0f)
                {
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
         * AudioClip set to match walking or running and sound effect plays
         */

        if (Input.GetKey(east) || Input.GetKey(west) || Input.GetKey(north) || Input.GetKey(south))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.loop = true;
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
                audioSource.clip = walkingClip;
                animController.SetBool("isWalking", true);
                animController.SetBool("isRunning", false);
            }
        }
       
        else
        {
            //stop audio
            if (audioSource.clip == walkingClip || audioSource.clip == runningClip) { audioSource.clip = null; }
            animController.SetBool("isRunning", false);
            animController.SetBool("isWalking", false);
        }


    }

}

