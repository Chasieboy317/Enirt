using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arenaPuzzleStart : MonoBehaviour
{

    public moveWall[] wallsToMove;
    public GameObject[] players;
    public float triggerPos;

    public float startPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (players[0].transform.position.z < triggerPos && players[1].transform.position.z < triggerPos) {
           setUpArena();
       }
    }

    void setUpArena() {
        foreach (moveWall wall in wallsToMove) {
            wall.enable();
        }

    }
}
