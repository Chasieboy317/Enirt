using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotDoppelgangerScript : RobotController
{
    // Start is called before the first frame update
    void Start()
    {
        SetControls();

        south = KeyCode.UpArrow;
        east = KeyCode.LeftArrow;
        north = KeyCode.DownArrow;
        west = KeyCode.RightArrow;
    }

    // Update is called once per frame
    
    void Update()
    {
        playerMovement();
    }
    
}
