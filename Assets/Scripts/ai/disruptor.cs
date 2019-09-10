using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    Disruptor type enemies try their best to prevent players from completing puzzles. 
    They are retarded however, and will lock on to the first player to be on a puzzle piece.
    If no players are on a puzzle piece anymore, they target the closes player.
*/
public class disruptor : enemy
{
    Animator animationController; // Seems to be used for Animation syncing. IDK
    public PressurePlate[] puzzlePieces; // List of puzzle pieces that the disruptor will guard
    private bool targetLocked = false; // Acquire the first person to step on a pressure plate, and don't switch (These AI are retarded)
    // Only public for testing purposes
    /*private*/ public GameObject target; // The target the AI will go after

    private bool noneTriggered = true; // Check if no more pressure plates are triggered

    // Simple 2D (top down) movement scheme for implementation testing, since I don't understand the animations and stuff
    float angle; // Angle to target

    // Update is called once per frame
    void Update() {
        // Fuck you Unity... its right there.....
       //foreach (GameObject object in puzzlePieces) {
        for (int i = 0; i < puzzlePieces.Length; ++i) {
           noneTriggered = true;
           if (puzzlePieces[i].triggered) {
               noneTriggered = false; // Set if any pressure plate is triggered
               if (targetLocked == false) {
                    targetLocked = true; // Get target if none is active
                    target = puzzlePieces[i].triggerEntity;
               }
               break; // Do not loop through other pressure plates... will just reset noneTriggered
           }
       }

       if (noneTriggered) {
           targetLocked = false;  // Allow new target acquisition, without stopping pursuit of current target
       }

       if (target != null) {
           // I don't understand much of the animation/movement system, but this is where the AI follows the player
           // TODO: Look into this
           Vector3 vectorToTarget = target.transform.position - transform.position; // Find target
           angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90; // Gat angle to face target
       }
    }

    void FixedUpdate() {
        // Need to add movement
    }
}
