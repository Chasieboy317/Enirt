using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for Doppelganger 'AI' 
//functionally behaves the same as the knight, except directions are swapped
public class KnightDoppelgangerController : KnightController
{
    // Start is called before the first frame update
    void Start()
    {
        SetControls();
        //Same controls as player except swap the directions so movement is mirrored
        south = KeyCode.W;
        east = KeyCode.A;
        north = KeyCode.S;
        west = KeyCode.D;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
    }
}
