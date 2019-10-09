using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Extends playerController to provide the unique functionality for the Robot: aiming, shooting, crawling
 */
public class RobotController : PlayerController
{
    //Key codes for actions unique to knight
    public KeyCode crawling;
    public KeyCode aim;
    public KeyCode shoot;

    public float crawlTime = 2f;
    public float startCrawlTime;
    //box collider - gets changed for crawling and then changed back
    public Vector3 center = new Vector3( 0, 1, 0.35f );
    public Vector3 size = new Vector3( 0.5f, 2, 0.7f);
    public Vector3 crawlCenter = new Vector3(0, 0.4f, 0.35f);
    public Vector3 crawlSize = new Vector3(0.5f, 0.8f, 2);

    public Transform firePoint;
    public GameObject BulletPrefab;
    public float fireRate = 1f;
    public float fireTime;

    //for aiming
    public int screenHeight;
    public GameObject gun;
    public int angle;


    // Start is called before the first frame update
    void Start()
    {
        SetControls();
    }

    public void SetControls()
    {
        OnStart(); //base class

        screenHeight = Screen.height;

        //Set unique action controls
        aim = KeyCode.O;
        shoot = KeyCode.Mouse0; //left mouse
        crawling = KeyCode.P;

        fireTime = Time.time;
    }

    //get gun angle corresponding to height on the screen
    public int rotateGun(int h)
    {
        if (h < 0)
        {
            return 45;
        }
        else if (h >= 0 && h <= 6)
        {
            return 120 - h * 10;
        }
        else
        {
            return 135;
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
    }

    public void playerMovement()
    {
        OnUpdate(); //base class

        //reset boxColCenter
        if (Time.time > runJumpStart + runJumpTime && boxCollider.center.y != boxColCenter.y && Time.time - startCrawlTime > crawlTime)
        {
            rigBody.useGravity = true;
            boxCollider.center = boxColCenter;
        }

        /*
         * CRAWL
         * For this the boxCollider for the player is editted to suit the animation
         */
        if (Input.GetKey(crawling))
        {
            startCrawlTime = Time.time;
            rigBody.useGravity = false;
            boxCollider.enabled = false;
            boxCollider.size = crawlSize;
            boxCollider.center = crawlCenter;
            boxCollider.enabled = true;
            rigBody.useGravity = true;
            animController.SetBool("isCrawling", true);
        }
        else 
        {
            //check that the player can't stand up while under something
            RaycastHit objAbove;
            
            if (!Physics.Raycast(this.transform.position, Vector3.up,out objAbove) || Vector3.Distance(objAbove.point, transform.position)<2.0f)
            {
                animController.SetBool("isCrawling", false);
                if (Time.time - startCrawlTime > crawlTime && !(Time.time > startCrawlTime + crawlTime + 2f))
                {
                    rigBody.useGravity = false;
                    if (boxCollider.enabled == true)
                    {
                        boxCollider.enabled = false;
                    }
                    boxCollider.size = size;
                    boxCollider.center = center;
                    boxCollider.enabled = true;
                    rigBody.useGravity = true;
                }
            }
        }

        /*
         * SHOOt
         */
        if (Input.GetKey(aim))
        {
            animController.SetBool("isShooting", true);
            
            //Rotate gun, to visually display new gun direction
            angle = rotateGun((int)(((Input.mousePosition).y / screenHeight) * 10));
            gun.transform.localEulerAngles = new Vector3(gun.transform.localEulerAngles.x, angle, gun.transform.localEulerAngles.z); 

            //On shoot, instantiate bullet prefab with firepoint position and rotation
            if (Input.GetKey(shoot))
            {
                if (Time.time - fireTime > fireRate)
                {
                    Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
                    fireTime = Time.time;
                }
                
            }
        }
        else
        {
            animController.SetBool("isShooting", false);
        }
    }

}
