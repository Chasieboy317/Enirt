using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script inherits from turnOnGravity to emulate falling
 * it is specifically used in level 3 to enable the knight to jump onto the object once it has fallen to the correct height
 */
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
