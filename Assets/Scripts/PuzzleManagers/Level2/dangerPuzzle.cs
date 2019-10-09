using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Controls wether or not puzzle 4 has been cleared
 */
public class dangerPuzzle : MonoBehaviour
{
    public puzzleController currentPuzzle;
    public PlayerController[] players;

    // Update is called once per frame
    void Update()
    {
        // Complete if players pass the gate
        if (players[0].transform.position.z < transform.position.z && players[1].transform.position.z < transform.position.z ) {
            currentPuzzle.Clear();
            gameObject.SetActive(false);
        }
    }
}
