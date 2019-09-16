using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myLever : lever
{
    public PuzzleBlock[] puzzleBlocks;
    public bool alternating;

    public override void toggle()
    {
        activated = activated ? false : true;
        cycle = true;
        currentTime = 0.0f;
        transform.position = startPos;
        controlBlocks();
    }

    public void controlBlocks()
    {
        if (alternating)
        {
            puzzleBlocks[currentIndex].toggle();
            currentIndex = currentIndex == puzzleBlocks.Length - 1 ? 0 : currentIndex+1;
        }
        else
        {
            foreach (PuzzleBlock pb in puzzleBlocks)
            {
                pb.toggle();
            }
        }
    }
}
