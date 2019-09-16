using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dangerPuzzle : MonoBehaviour
{
    public puzzleController currentPuzzle;
    public PlayerController[] players;

    // Update is called once per frame
    void Update()
    {
        if (players[0].transform.position.z < transform.position.z && players[1].transform.position.z < transform.position.z ) {
            currentPuzzle.Clear();
            gameObject.SetActive(false);
        }
    }
}
