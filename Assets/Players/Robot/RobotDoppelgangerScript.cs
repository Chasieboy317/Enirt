using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Robot Doppelganger 'AI'
public class RobotDoppelgangerScript : RobotController
{
    // Start is called before the first frame update
    void Start()
    {
        SetControls();

        //Same controls as player except swap the directions so movement is mirrored

        south = KeyCode.UpArrow;
        east = KeyCode.LeftArrow;
        north = KeyCode.DownArrow;
        west = KeyCode.RightArrow;
    }

        
    void Update()
    {
        playerMovement();
    }
    
}
