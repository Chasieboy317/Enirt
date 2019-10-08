using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Script that controls the arena puzzle in level 2 
*/
public class arenaPuzzleStart : MonoBehaviour
{

    public moveWall[] wallsToMove; // Set of walls that will move when the arena activates - sets up the arena
    public GameObject[] players; // Both players need to be in a certain area for the arena to activate
    public float triggerPos; // Position players need to pass to activate arena

    private bool triggered = false;

    // Update is called once per frame
    void Update()
    {
        // Check if players stepped accross the activation zone
        if (!triggered) {
            if (players[0].transform.position.z < triggerPos && players[1].transform.position.z < triggerPos) {
                triggered = true;
                setUpArena();
            }
        }
    }
    
    /*
        Moves walls into place for the puzzle to begin
        Some walls will move up, while others get shifted down
     */
    void setUpArena() {
        foreach (moveWall wall in wallsToMove) {
            wall.enable();
        }

    }
}
