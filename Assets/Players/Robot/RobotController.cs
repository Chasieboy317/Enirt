using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : PlayerController
{
    //Key codes for actions unique to knight
    public KeyCode crawling;
    public KeyCode aim;
    public KeyCode shoot;
    public KeyCode launchBomb;

    // Start is called before the first frame update
    void Start()
    {
        OnStart(); //base class

        aim = KeyCode.Greater;
        shoot = KeyCode.Mouse0; //left mouse
        launchBomb = KeyCode.Mouse1; //right click
        crawling = KeyCode.Less; 
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate(); //base class

        /*
         * SHOOT
         */
        if (Input.GetKey(crawling))
        {
            animController.SetBool("isCrawling", true);
        }
        else
        {
            animController.SetBool("isCrawling", false);
        }

        /*
         * Blocking
         */
        if (Input.GetKey(aim))
        {
            animController.SetBool("isAiming", true);

            //implement shooting and bomb launching
        }
        else
        {
            animController.SetBool("isAiming", false);
        }
    }
}
