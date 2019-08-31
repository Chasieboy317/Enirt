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

    public float crawlTime = 2.20f;
    public float startCrawlTime;
    //box collider - gets changed for crawling and then changed back
    public Vector3 center = new Vector3( 0, 1, 0.35f );
    public Vector3 size = new Vector3( 0.5f, 2, 0.7f);

    public Vector3 crawlCenter = new Vector3(0, 0.4f, 0.35f);
    public Vector3 crawlSize = new Vector3(0.5f, 0.8f, 2);

    // Start is called before the first frame update
    void Start()
    {
        OnStart(); //base class

        aim = KeyCode.O;
        shoot = KeyCode.Mouse0; //left mouse
        //launchBomb = KeyCode.Mouse1; //right click
        crawling = KeyCode.P;
    }

    // Update is called once per frame
    void Update()
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
            //check that the player can't stand up while under something?
            animController.SetBool("isCrawling", false);
            if (Time.time - climbStartTime > climbTime)
            {
                boxCollider.enabled = false;
                boxCollider.size = size;
                boxCollider.center = center;
                boxCollider.enabled = true;
            }
        }

        /*
         * SHOOt
         */
        if (Input.GetKey(aim))
        {
            animController.SetBool("isShooting", true);

            //implement shooting and bomb launching
        }
        else
        {
            animController.SetBool("isShooting", false);
        }
    }
}
