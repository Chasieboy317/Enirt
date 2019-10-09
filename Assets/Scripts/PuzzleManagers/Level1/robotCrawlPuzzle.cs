using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotCrawlPuzzle : MonoBehaviour
{
    public puzzleController currentPuzzle;
    public PlayerController[] players;

    void Update()
    {
        if (players[0].transform.position.z < transform.position.z && players[1].transform.position.z < transform.position.z ) {
            currentPuzzle.Clear();
            gameObject.SetActive(false);
        }

    }
}
