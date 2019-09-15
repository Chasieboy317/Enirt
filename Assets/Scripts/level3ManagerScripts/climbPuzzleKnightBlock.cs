using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climbPuzzleKnightBlock : turnOnGravity
{
    

    // Update is called once per frame
    void Update()
    {
        onUpdate();

        if (enableGravity)
        {
            this.transform.tag = "KnightJumpOnto";
        }
    }
}
