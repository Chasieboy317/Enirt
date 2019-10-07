using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myLever : lever
{
    public PuzzleBlock[] puzzleBlocks;
    public bool alternating; //this variable determines whether the level alternates between the blocks it controls. It will move a single block at a time
                             //but will control another block in its next turn 

    //method used to reset the state of the level to one in which it is ready to be pulled again
    public override void toggle()
    {
        activated = activated ? false : true;
        cycle = true;
        currentTime = 0.0f;
        transform.position = startPos;
        controlBlocks(); //this call is what alternates between the blocks the level controls
    }

    public void controlBlocks()
    {
        if (alternating)
        {
            puzzleBlocks[currentIndex].toggle(); //move the current block
            currentIndex = currentIndex == puzzleBlocks.Length - 1 ? 0 : currentIndex+1; //set the next block to be the current block activated when the level is pulled again
        }
        else
        {
            //move all the blocks the level controls
            foreach (PuzzleBlock pb in puzzleBlocks)
            {
                pb.toggle(); 
            }
        }
    }
}
