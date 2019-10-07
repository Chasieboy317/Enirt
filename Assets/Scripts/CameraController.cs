using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera robot;
    public Camera knight;
    public Camera main;
    private GameObject r;
    private GameObject k;

    public float horizontalDistance;
    public float verticalDistance;

    void Start()
    {
        //find the players
        r = GameObject.FindWithTag("Robot");
        k = GameObject.FindWithTag("Knight");
    }

    void Update()
    {
        //if the distance between the players horizontally is greater than the distance specified, disable the main camera and enable splitscreen
        if (Mathf.Abs(k.transform.position.z-r.transform.position.z)>horizontalDistance||
            Mathf.Abs(k.transform.position.y - r.transform.position.y)>verticalDistance)
        {
            robot.enabled = true;
            knight.enabled = true;
            main.enabled = false;
        }
        //if the distance between the players horizontally is less than the distance specified, disable splitscreen and enable the main camera
        else if (Mathf.Abs(k.transform.position.z - r.transform.position.z)<horizontalDistance&&
            Mathf.Abs(k.transform.position.y - r.transform.position.y)<verticalDistance)
        {
            robot.enabled = false;
            knight.enabled = false;
            main.enabled = true;
        }
    }
}
