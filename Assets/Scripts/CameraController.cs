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

    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        //find the players
        r = GameObject.FindWithTag("Robot");
        k = GameObject.FindWithTag("Knight");
    }

    // Update is called once per frame
    void Update()
    {
        //if the distance between the players is greater than the distance specified, disable the main camera and enable splitscreen
        if (Mathf.Abs(k.transform.position.z-r.transform.position.z)>distance)
        {
            robot.enabled = true;
            knight.enabled = true;
            main.enabled = false;
        }
        //else if the distance between the players is less than the distance specified, disable splitscreen and enable the main camera
        else if (Mathf.Abs(k.transform.position.z - r.transform.position.z) < distance)
        {
            robot.enabled = false;
            knight.enabled = false;
            main.enabled = true;
        }
        
    }
}
