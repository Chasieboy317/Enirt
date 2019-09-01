using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightDoppelgangerController : KnightController
{
    // Start is called before the first frame update
    void Start()
    {
        SetControls();

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
