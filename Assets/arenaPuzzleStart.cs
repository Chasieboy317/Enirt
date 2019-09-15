using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Script that controls the arena puzzle in level 2 */
public class arenaPuzzleStart : MonoBehaviour
{

    public moveWall[] wallsToMove; // Set of walls that will move when the arena activates - sets up the arena
    public GameObject[] players; // Both players need to be in a certain area for the arena to activate
    public float triggerPos; // Position players need to pass to activate arena

    private bool triggered = false;
    // TODO: define the area for activating the arena better... replace forward wall with a gate

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!triggered) {
            if (players[0].transform.position.z < triggerPos && players[1].transform.position.z < triggerPos) {
                triggered = true;
                setUpArena();
            }
        }
    }

    void setUpArena() {
        foreach (moveWall wall in wallsToMove) {
            wall.enable();
        }

    }
}
