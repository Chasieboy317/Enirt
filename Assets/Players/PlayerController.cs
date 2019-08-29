using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animController;
    public Rigidbody rigBody;
    public Collider boxCollider;

    public bool dead = false;
    public int health =10;

    //This will be used to determine whether 'jump' should be enabled for the player
    public string climbableTag;
    public float climableMaxDixtance;
    public float climableMinDistance;
    public float climbTime;
    public float climbStartTime;
    public float jumpDownTime = 0.5f;

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
        rigBody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<Collider>();

        //Maybe use a variable to check whether configured or not?
        if(this.tag == "Knight")
        {
            north = KeyCode.W;
            west = KeyCode.A;
            south = KeyCode.S;
            east = KeyCode.D;

            push = KeyCode.Q;
            jump = KeyCode.Space;

            toggle = KeyCode.LeftShift;

            climbableTag = "KnightJumpOnto";
            climableMaxDixtance = 1.8f;
            climableMinDistance = 1.2f;
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

            toggle = KeyCode.L; //KeyCode.KeypadEnter

            climbableTag = "RobotClimbOnto";
            climableMaxDixtance = 1.7f;// 1.5f;
            climableMinDistance = 0f; //0.5f;
            climbTime = 4.1f;
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
        if (!running && Input.GetKey(jump))
        {
            //only enable jump if it is an object the player can jump onto 
            Vector3 start = this.transform.position + new Vector3(0,0.9f,0);
            Vector3 direction = this.transform.forward;
            RaycastHit hit;
            if (Physics.Raycast(start, direction, out hit))
            {
                Debug.DrawRay(start, direction * 10, Color.green);
                if(climbableTag == hit.transform.tag) //climbable object
                {
                    float distance = Vector3.Distance(hit.point, transform.position);

                    Debug.Log(distance);
                    //close enough
                    if (distance >= climableMinDistance && distance <= climableMaxDixtance)
                    {
                        climbStartTime = Time.time;
                        boxCollider.enabled = false;
                        
                        animController.SetBool("jump", true);
                        animController.SetBool("jumpingOnto", true);
                    }
                }
                //hit.collider.gameObject.SetActive(false);
            }
            else
            {
                
                if (this.transform.position.y >= 0.5)
                {
                    animController.SetBool("jump", true);
                    animController.SetBool("jumpingOnto", false);
                }
            }

        }
        //renable box collider when jump time has passed
        else if (!boxCollider.enabled && Time.time - climbStartTime > climbTime)
        {
            boxCollider.enabled = true;
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
            Vector3 startPos = this.transform.position + new Vector3(0, 0.3f, 0);
            Vector3 dir = this.transform.forward;
            
            RaycastHit hitObj;
            if (Physics.Raycast(startPos, dir, out hitObj))
            {
                if (hitObj.transform.gameObject.GetComponent("Pushable") != null)
                {
                    Debug.DrawRay(startPos, dir * 10, Color.red);
                    float dist = Vector3.Distance(hitObj.point, transform.position);
                    Debug.Log(dist);
                    if (dist <= 3.3f)
                    {
                        Debug.Log("transform.forward" + dir);
                        hitObj.transform.gameObject.GetComponent("Pushable").SendMessage("wasPushed", dir);
                        animController.SetBool("isPushing", true);
                    }
                }   
            }
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
                    animController.SetBool("jump", true);
                }
                else
                {
                    animController.SetBool("jump", false);
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
         
        if (!dead && health <= 0)
        {
            Debug.Log("isDead set");
            animController.SetBool("isDead", true);
            dead = true;
            //animController.SetBool("isDead", false);
        }
        */
        
    }

    //function used to decrease health. Can be called from onTriggerEnter or something
    void takeDamage()
    {
        health -= 1;
    }

}
