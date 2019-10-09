using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is used to control the main camera
//this camera should have both players in view
public class MainCameraFollow : MonoBehaviour
{
    public Vector3 offset; //pre-defined offest that should be added to the position of the camera in addition to the interpolated position of the players
    private GameObject robot;
    private GameObject knight;

    //find the players
    void Start()
    {
        robot = GameObject.FindWithTag("Robot");
        knight = GameObject.FindWithTag("Knight");
    }

    void Update()
    {
        //set the position of the camera to be halfway between the players horizontally and vertically
        //add whatever offset the user specifies to this position
        transform.position = new Vector3(transform.position.x, (robot.transform.position.y + knight.transform.position.y) / 2,
            (robot.transform.position.z + knight.transform.position.z) / 2) + offset;
    }
}
