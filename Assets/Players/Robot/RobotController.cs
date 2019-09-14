using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : PlayerController
{
    //Key codes for actions unique to knight
    public KeyCode crawling;
    public KeyCode aim;
    public KeyCode shoot;
    //public KeyCode launchBomb;

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
    

    // Start is called before the first frame update
    void Start()
    {
        SetControls();
        screenHeight = Screen.height;
    }

    public void SetControls()
    {
        OnStart(); //base class

        //firePoint = transform.Find("FirePoint");
        aim = KeyCode.O;
        shoot = KeyCode.Mouse0; //left mouse
        crawling = KeyCode.P;

        fireTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
    }

    public void playerMovement()
    {
        OnUpdate(); //base class

        /*
         * CRAWL
         */
        if (Input.GetKey(crawling))
        {
            startCrawlTime = Time.time;
            boxCollider.enabled = false;
            boxCollider.size = crawlSize;
            boxCollider.center = crawlCenter;
            boxCollider.enabled = true;

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
                    if(boxCollider.enabled == true)
                    {
                        boxCollider.enabled = false;
                    }
                    boxCollider.size = size;
                    boxCollider.center = center;
                    boxCollider.enabled = true;   
                }
            }
        }

        /*
         * SHOOt
         */
        if (Input.GetKey(aim))
        {
            animController.SetBool("isShooting", true);
            //rotate towards mouse y
            
            Debug.Log("mouse y / screenHeight * 10 " + (int)(((Input.mousePosition).y / screenHeight) * 10));
            int angle = rotateGun((int)(((Input.mousePosition).y / screenHeight) * 10));
            gun.transform.localEulerAngles = new Vector3(gun.transform.localEulerAngles.x, angle, gun.transform.localEulerAngles.z); 

            //implement shooting
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

    public int rotateGun(int h)
    {
        if (h < 0)
        {
            return 45;
        }
        else if( h>=0 && h <= 6)
        {
            return 120 - h * 10;
        }
        else
        {
            return 135;
        }
        /*
        if (h < 0)
        {
            gun.transform.localEulerAngles = new Vector3(gun.transform.localEulerAngles.x, 135, gun.transform.localEulerAngles.z);
        }
        else if (h == 0)
        {
            gun.transform.localEulerAngles = new Vector3(gun.transform.localEulerAngles.x, 120, gun.transform.localEulerAngles.z);
        }
        else if (h == 1)
        {
            gun.transform.localEulerAngles = new Vector3(gun.transform.localEulerAngles.x, 110, gun.transform.localEulerAngles.z);
        }
        else if (h == 2)
        {
            gun.transform.localEulerAngles = new Vector3(gun.transform.localEulerAngles.x, 100, gun.transform.localEulerAngles.z);
        }
        else if (h == 3)
        {
            gun.transform.localEulerAngles = new Vector3(gun.transform.localEulerAngles.x, 90, gun.transform.localEulerAngles.z);
        }
        else if (h == 4)
        {
            gun.transform.localEulerAngles = new Vector3(gun.transform.localEulerAngles.x, 80, gun.transform.localEulerAngles.z);
        }
        else if (h == 5)
        {
            gun.transform.localEulerAngles = new Vector3(gun.transform.localEulerAngles.x, 70, gun.transform.localEulerAngles.z);
        }
        else if (h == 6)
        {
            gun.transform.localEulerAngles = new Vector3(gun.transform.localEulerAngles.x, 60, gun.transform.localEulerAngles.z);
        }
        else 
        {
            gun.transform.localEulerAngles = new Vector3(gun.transform.localEulerAngles.x, 45, gun.transform.localEulerAngles.z);
        }
        */
    }
}
