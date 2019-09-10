using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    The fighter, or brawler type enemy is your simple "got hit player" type enemy. They aren't
    Particularly diverse in what they do, but will target players they can get to.
*/
public class fighter : MonoBehaviour
{
    Animator animationController;
    public GameObject[] players; // List of players to be targeted. Yeah I know there are only two..
    private bool targetLocked = false; //TODO: Add patrol route if no player is targeted

    // Public for testing purposes
    /*private*/ public GameObject target;

    // Update is called once per frame
    void Update()
    {
        if (targetLocked == false) {
            target = (players[1].transform.position - transform.position).magnitude > (players[0].transform.position - transform.position).magnitude ? players[0] : players[1];
            targetLocked = true;
        }
    }
    void FixedUpdate() {

    }
}
