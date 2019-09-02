using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
           if (puzzlePieces[i].isTriggered) {
               noneTriggered = false; // Set if any pressure plate is triggered
               if (targetLocked == false) {
                    targetLocked = true; // Get target if none is active
                    target = puzzlePieces[i].triggerEntity;
               }
           }
       }

       if (noneTriggered) {
           targetLocked = false;  // Allow new target acquisition, without stopping pursuit of current target
       }

       if (target != null) {
           // I don't understand much of the animation/movement system, but this is where the AI follows the player
           Vector3 vectorToTarget = target.transform.position - transform.position; // Find target
           angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90; // Gat angle to face target
       }
    }

    void FixedUpdate() {
        // Simple physics based movement as a prelim test to see if the AI acts as it should
        // This would have to change to use our rigging and animation system
        myRB.AddForce(myRB.transform.up * speed);
        // Needs quarternion for my simple version. blegh
        //myRB.MoveRotation(angle);
    }
}
