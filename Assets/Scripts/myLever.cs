using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myLever : lever
{
    public PuzzleBlock[] puzzleBlocks;
    public bool alternating;

    private float currentTime;
    private float waitTime;
    private bool cycle;
    private Vector3 startPos;
    private int currentIndex;

    // Start is called before the first frame update
   
    
    void Update()
    {
        move();
    }
    
    // Update is called once per frame
    public void toggle()
    {
        activated = activated ? false : true;
        cycle = true;
        currentTime = 0.0f;
        transform.position = startPos;
        controlBlocks();
    }

    

    void controlBlocks()
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
