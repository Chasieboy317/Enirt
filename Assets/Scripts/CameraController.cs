using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is used to control whether splitscreen cameras should be active, or just one camera should be active
public class CameraController : MonoBehaviour
{
    public Camera robot; //the camera following the robot
    public Camera knight; //the camera following the knight
    public Camera main; //the main camera
    private GameObject r; //the robot
    private GameObject k; //the knight

    public float horizontalDistance; //the horizontal distance between the players that must be met for splitscreen to be enabled
    public float verticalDistance; //the vertical distance between the players that must be met for splitscreen to be enabled

    void Start()
    {
        //find the players
        r = GameObject.FindWithTag("Robot");
        k = GameObject.FindWithTag("Knight");
    }

    //check whether splitscreen should or shouldn't be enabled and enable/disable it as necessary
    void Update()
    {
        //if the distance between the players horizontally and vertically is greater than the distance specified, disable the main camera and enable splitscreen
        if (Mathf.Abs(k.transform.position.z-r.transform.position.z)>horizontalDistance||
            Mathf.Abs(k.transform.position.y - r.transform.position.y)>verticalDistance)
        {
            robot.enabled = true;
            knight.enabled = true;
            main.enabled = false;
        }
        //if the distance between the players horizontally and vertically is less than the distance specified, disable splitscreen and enable the main camera
        else if (Mathf.Abs(k.transform.position.z - r.transform.position.z)<horizontalDistance||
            Mathf.Abs(k.transform.position.y - r.transform.position.y)<verticalDistance)
        {
            robot.enabled = false;
            knight.enabled = false;
            main.enabled = true;
        }
    }
}
